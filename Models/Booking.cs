using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hotel.api.models
{
    public class Booking
    {
        [Key]
        public string IdBooking { get; set; }

        public DateTime StartDateBooking { get; set; }

        public DateTime EndDateBooking { get; set; }

        public bool IsBooked { get; set;}

        public string IdRoom { get; set;}

    }
}
