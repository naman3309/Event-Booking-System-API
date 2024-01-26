using Event_Booking_System_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Event_Booking_System_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeeController : ControllerBase
    {
        private readonly IAttendeesRepository _attendeesRepository;
        public AttendeeController(IAttendeesRepository attendeesRepository) 
        {
            _attendeesRepository = attendeesRepository;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll() 
        {
            var result = _attendeesRepository.GetAll();
            return Ok(result);
        }
        [HttpGet("byEventId/{id}")]
        public async Task<IActionResult> GetByEventId(int id) 
        {
            var result = _attendeesRepository.GetAllAttendeesByEvent(id);
            return Ok(result);
        }
    }
}
