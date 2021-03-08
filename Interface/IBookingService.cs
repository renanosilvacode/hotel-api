using hotel.api.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel.api.Interface
{
    public interface IBookingService
    {
        public Task<Booking> CreateBooking(Booking booking);
        public Task<Booking> GetBookingById(string idBooking);
        public bool IsRoomAvailable(Booking booking);
        public Task<Booking> UpdateBooking(Booking booking);
        public Task<Booking> CancelBooking(string idBooking);

    }
}
