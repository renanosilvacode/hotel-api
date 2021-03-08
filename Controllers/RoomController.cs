using hotel.api.models;
using HOTEL.Api.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace hotel.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly DataContext _context;

        public RoomController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Room>> GetAll() =>
            _context.Rooms.ToList();
    }
}