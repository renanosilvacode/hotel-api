using hotel.api.models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace HOTEL.Api.Data
{
    public static class SeedData
    {
        public static void Initialize(DataContext context)
        {
            if (!context.Hotels.Any())
            {
                var guidHotelID = Guid.NewGuid().ToString();

                context.Hotels.AddRange(
                    new Hotel 
                    {
                        IdHotel = guidHotelID,
                        NameHotel = "Cancun Hotel",
                        Rooms = {}
                    }
                );

                context.SaveChanges();
            }

            if (!context.Rooms.Any())
            {
                var guidRoomID = Guid.NewGuid().ToString();

                context.Rooms.AddRange(
                    new Room
                    {
                        IdRoom = guidRoomID,
                        NumberBeds = 2,
                        Booking = {}
                    }
                );

                context.SaveChanges();
            }

            if (!context.Bookings.Any())
            {

                context.Bookings.AddRange(
                    new Booking
                    {
                        IdBooking = Guid.NewGuid().ToString(),
                        StartDateBooking = DateTime.Now.AddDays(10),
                        EndDateBooking = DateTime.Now.AddDays(13),
                        IsBooked = true,
                        IdRoom = Guid.NewGuid().ToString()
                    }
                );

                context.Bookings.AddRange(
                    new Booking
                    {
                        IdBooking = Guid.NewGuid().ToString(),
                        StartDateBooking = DateTime.Now.AddDays(20),
                        EndDateBooking = DateTime.Now.AddDays(23),
                        IsBooked = true,
                        IdRoom = Guid.NewGuid().ToString()
                    }
                );

                context.SaveChanges();
            }
        }
    }
}