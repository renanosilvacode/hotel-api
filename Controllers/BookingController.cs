using hotel.api.Interface;
using hotel.api.models;
using hotel.api.Services;
using HOTEL.Api.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
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
            try
            {
                var bookingToBeCreated = await _bookingService.CreateBooking(booking);

                return CreatedAtAction(nameof(GetBookingById), new { id = bookingToBeCreated.IdBooking }, bookingToBeCreated);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBooking(Booking booking)
        {
            try
            {
                var bookingToBeCreated = await _bookingService.UpdateBooking(booking);

                if (bookingToBeCreated != null)
                    return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelBooking(string id)
        {
            try
            {
                var bookingToBeCanceled = await _bookingService.CancelBooking(id);

                if (bookingToBeCanceled != null)
                    return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return BadRequest();
        }

        [HttpGet]
        public ActionResult<bool> IsRoomAvailable(Booking booking) => _bookingService.IsRoomAvailable(booking);
        
    }
}