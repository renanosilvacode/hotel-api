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
        }
    }
}