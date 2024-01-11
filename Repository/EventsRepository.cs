using Event_Booking_System_API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

namespace Event_Booking_System_API.Repository
{
    public class EventsRepository:IEventRepository
    {
        private readonly APIDbContext _context;
        public EventsRepository(APIDbContext context)
        {
            _context = context;
        }

        public async Task<List<Events>> GetAllEvents()
        {
            var events = await _context.Events.ToListAsync<Events>();
            return events;
        }

        public async Task<Events> GetEventsByIdAsync(int id)
        {
            var element = await _context.Events.FindAsync(id);
            return element;
        }

        public async Task<int> GetEventIdByName(string name)
        {
            var res = await _context.Events.Where(e => EF.Functions.Like(e.EventName, $"%{name}%")).Select(e=>e.Id).FirstOrDefaultAsync();
            return res;
        }
        
        public async Task<int> Get_seats_left_by_Id(int id)
        {
            var res = await _context.Events.FindAsync(id);
            return res.Totalseats;
        }

        public async Task<DateTime> Get_Date_Time_by_Id(int id)
        {
            var res = await _context.Events.FindAsync(id);
            return new DateTime(res.EventDate, res.EventTime);
        }
        
        public async Task<int> AddEvent(Events _event){
            var e = new Events()
            {
                EventName = _event.EventName,
                EventDescription = _event.EventDescription,
                EventDate = _event.EventDate,
                EventTime = _event.EventTime,
                EventType = _event.EventType,
                EventVenue = _event.EventVenue,
                attendees = _event.attendees,
                Totalseats = _event.Totalseats
            };
            _context.Events.Add(e);
            await _context.SaveChangesAsync();
            return e.Id;
        }

        public async Task Update_event_details(int id, JsonPatchDocument body)
        {
            var e = await _context.Events.FindAsync(id);
            if(e!= null) {
                body.ApplyTo(e);
                await _context.SaveChangesAsync();
            }

        }


    }
}
