using Event_Booking_System_API.Model;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Event_Booking_System_API.Repository
{   
    public class BookingRepository
    {
        private readonly APIDbContext _context;

        BookingRepository(APIDbContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetTicketIdByAttendeeId(int attendee_id)
        {
            var ticket_Id= _context.Bookings.Where(b=>b.Attendee_Id==attendee_id).ToList();
            return ticket_Id;
        }
        public async Task<List<Booking>> GetTicketIdByEventId(int event_id)
        {
            var ticket_Id= _context.Bookings.Where(b=>b.Event_Id==event_id).ToList();
            return ticket_Id;
        }

        
    }
}
