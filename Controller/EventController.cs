using Event_Booking_System_API.Model;
using Event_Booking_System_API.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Event_Booking_System_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository) {
            _eventRepository= eventRepository;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllEvents()
        {
            var _events = await _eventRepository.GetAllEvents();
            return Ok(_events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvents([FromRoute]int id ) 
        {
            var _event = await _eventRepository.GetEventsByIdAsync(id);
            if ( _event == null ) { return NotFound(); }
            return Ok(_event);
        }

        [HttpPost("addevent")]
        public async Task<IActionResult> AddEvent([FromBody]Events _event)
        {
            var id = await _eventRepository.AddEvent(_event);
            return Ok(id);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetEventByName(string name)
        {
            var _event = await _eventRepository.GetEventIdByName(name);
            if ( _event == null ) { return NotFound(); }
            return Ok(_event);
        }

        [HttpGet("{id}/available_seats")]
        public async Task<IActionResult> GetSeatLeft(int id)
        {
            var seats = await _eventRepository.Get_seats_left_by_Id(id);
            return Ok(seats);
        }

        [HttpGet("{id}/getdatetime")]
        public async Task<IActionResult> GetDateTime(int id)
        {
            var date = await _eventRepository.Get_Date_Time_by_Id(id);
            return Ok(date);
        }

        [HttpGet("{id}/price")]
        public async Task<IActionResult> GetPrice(int id)
        {
            var price = await _eventRepository.Get_Ticket_Price(id);
            return Ok(price);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateEvent(int id,JsonPatchDocument jsonPatch)
        {
            await _eventRepository.Update_event_details(id, jsonPatch);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id) 
        {
            await _eventRepository.Delete_Event(id);
            return Ok();
        }
    }
}
