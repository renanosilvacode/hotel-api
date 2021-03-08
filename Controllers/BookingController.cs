using hotel.api.models;
using hotel.api.Services;
using HOTEL.Api.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoPets.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _bookingService;

        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBookingById(string id)
        {
            var booking = await _bookingService.GetBookingById(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(Booking booking)
        {
            var bookingToBeCreated = await _bookingService.CreateBooking(booking);

            return CreatedAtAction(nameof(GetBookingById), new { id = bookingToBeCreated.IdBooking }, bookingToBeCreated);
        }


        // DELETE action
    }
}