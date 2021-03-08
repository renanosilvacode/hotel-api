using hotel.api.Interface;
using hotel.api.models;
using HOTEL.Api.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel.api.Services
{
    public class BookingService : IBookingService
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
            try
            {
                if (ValidateBooking(booking))
                {
                    booking.IdBooking = Guid.NewGuid().ToString();
                    _context.Bookings.Add(booking);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return booking;
        }

        public async Task<Booking> GetBookingById(string idBooking)
        {
            var booking = await _context.Bookings.FindAsync(idBooking);
            return booking;
        }

        public bool IsRoomAvailable(Booking booking)
        {
            var isRoomAvailable = _context.Bookings.Where(b =>
                                            (booking.StartDateBooking >= b.StartDateBooking && booking.StartDateBooking <= b.EndDateBooking
                                            || booking.EndDateBooking >= b.StartDateBooking && booking.EndDateBooking <= b.EndDateBooking)
                                            && b.IsActive).Count() > 0;
            return isRoomAvailable;
        }

        public async Task<Booking> UpdateBooking(Booking booking)
        {
            try
            {
                if (ValidateBooking(booking))
                {
                    var bookingToBeUpdate = await GetBookingById(booking.IdBooking);

                    if (bookingToBeUpdate == null)
                        throw new Exception("Booking cannot be updated");

                    _context.Entry(booking).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return bookingToBeUpdate;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;
        }

        public async Task<Booking> CancelBooking(string idBooking)
        {
            var bookingToBeCanceled = await GetBookingById(idBooking);

            if (bookingToBeCanceled == null)
                throw new Exception("Booking cannot be canceled.");

            bookingToBeCanceled.IsActive = false;
            await _context.SaveChangesAsync();

            return bookingToBeCanceled;
        }

        private bool ValidateBooking(Booking booking)
        {
            booking.StartDateBooking = booking.StartDateBooking.Date;
            booking.EndDateBooking = booking.EndDateBooking.Date;

            if (booking.EndDateBooking > booking.StartDateBooking.AddDays(MAX_DAYS_BOOKING_STAY))
                throw new Exception(string.Format("The stay cannot be longer than {0} days.", MAX_DAYS_BOOKING_STAY));

            if (booking.StartDateBooking > DateTime.Now.AddDays(MAX_DAYS_BOOKING_ADVANCE))
                throw new Exception(string.Format("A booking cannot be made mode than {0} in advance.", MAX_DAYS_BOOKING_ADVANCE));

            if (booking.StartDateBooking == DateTime.Now)
                throw new Exception(string.Format("You cannot reserve the room for today"));

            var isRoomBooked = IsRoomAvailable(booking);

            if (isRoomBooked)
                throw new Exception("Room is already Booked for the selected timeframe.");

            return true;
        }
    }
}
