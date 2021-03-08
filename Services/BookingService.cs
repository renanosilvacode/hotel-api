using hotel.api.Interface;
using hotel.api.models;
using HOTEL.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel.api.Services
{
    public class BookingService : IBooking
    {
        private readonly DataContext _context;
        private readonly int MAX_DAYS_BOOKING_STAY = 3;
        private readonly int MAX_DAYS_BOOKING_ADVANCE = 30;


        public BookingService(DataContext context)
        {
            _context = context;
        }
        public async Task<Booking> CreateBooking(Booking booking)
        {
            if (booking.EndDateBooking > booking.StartDateBooking.AddDays(MAX_DAYS_BOOKING_STAY))
                throw new Exception(string.Format("The stay cannot be longer than {0} days.", MAX_DAYS_BOOKING_STAY));

            if (booking.StartDateBooking > DateTime.Now.AddDays(MAX_DAYS_BOOKING_ADVANCE))
                throw new Exception(string.Format("A booking cannot be made mode than {0} in advance.", MAX_DAYS_BOOKING_ADVANCE));

            if (booking.StartDateBooking == DateTime.Now)
                throw new Exception(string.Format("You cannot reserve the room for today"));

            var isRoomBooked = _context.Bookings.Where(b => b.StartDateBooking >= booking.StartDateBooking && b.EndDateBooking <= booking.EndDateBooking).Count() > 0;

            if (!isRoomBooked)
                throw new Exception("Room is already Booked for the selected timeframe.");
            
            booking.IdBooking = Guid.NewGuid().ToString();
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return booking;
        }

        public async Task<Booking> GetBookingById(string idBooking)
        {
            var booking = await _context.Bookings.FindAsync(idBooking);
            return booking;
        }

    }
}
