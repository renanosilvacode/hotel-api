using hotel.api.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel.api.Interface
{
    public interface IBooking
    {
        public Task<Booking> CreateBooking(Booking booking);
        public Task<Booking> GetBookingById(string idBooking);

    }
}
