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

        public async Task<Events> GetEventIdByName(string name)
        {
            var res = await _context.Events.Where(e => EF.Functions.Like(e.EventName, $"%{name}%")).Select(e=>e).FirstOrDefaultAsync();
            return res ;
        }
        
        public async Task<int> Get_seats_left_by_Id(int id)
        {
            var res = await _context.Events.FindAsync(id);
            return res.Totalseats-res.Ticket_Sold_Quantity;
        }

        public async Task<DateTime> Get_Date_Time_by_Id(int id)
        {
            var res = await _context.Events.FindAsync(id);
            return new DateTime(res.EventDate, TimeOnly.Parse(res.EventTime));
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
                Totalseats = _event.Totalseats,
                Ticket_Price = _event.Ticket_Price
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
        
        public async Task Delete_Event(int id)
        {
            var _event = new Events() { Id = id };
            _context.Events.Remove(_event);
            await _context.SaveChangesAsync();
        }

        public async Task<int> Get_Ticket_Price(int id)
        {
            var _event = await _context.Events.FindAsync(id);
            if (_event != null && _event.Ticket_Price>=0) { return _event.Ticket_Price; }
            return -1;
        }

        
    }
}
