using Event_Booking_System_API.Model;
using Event_Booking_System_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet("")]
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

        [HttpPost("add_attendee")]
        public async Task<IActionResult> addAttendee([FromBody] Attendees attendee)
        {
            await _attendeesRepository.AddAttendee(attendee);
            return Ok();
        }

        [HttpPatch("update/{id}")]
        public async Task<IActionResult> updateByPatch([FromRoute]int id,[FromBody] JsonPatchDocument attendee)
        {
            await _attendeesRepository.UpdateAttendee_ByPatch(id, attendee);
            return Ok();
        }

        [HttpPut("")]
        public async Task<IActionResult> updateByPut([FromBody]Attendees attendees)
        {
            await _attendeesRepository.UpdateAttendee_ByPut(attendees);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete_Attendee(int id)
        {
            await _attendeesRepository.Delete_Attendee(id);
            return Ok();
        }
    }
}
