using hotel.api.models;
using HOTEL.Api.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ContosoPets.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly DataContext _context;

        public HotelController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Hotel>> GetAll() =>
            _context.Hotels.ToList();

        // GET by ID action

        // POST action

        // PUT action

        // DELETE action
    }
}