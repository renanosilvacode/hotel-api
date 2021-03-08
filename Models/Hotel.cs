using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hotel.api.models
{
    public class Hotel
    {
        [Key]
        public string IdHotel { get; set; }

        public string NameHotel { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
