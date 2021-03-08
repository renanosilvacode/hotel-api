using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hotel.api.models
{
    public class Room
    {
        [Key]
        public string IdRoom { get; set; }

        public int NumberBeds { get; set; }

        public Booking Booking { get; set; }
    }
}
