﻿using Event_Booking_System_API.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Event_Booking_System_API.Repository
{
    public class AttendeesRepository:IAttendeesRepository
    {
        private readonly APIDbContext _context;
        public AttendeesRepository(APIDbContext context) { 
            _context = context;
        }

        public async Task<List<Attendees>> GetAll()
        {
            var res = await _context.Attendees.ToListAsync<Attendees>();
            return res;
        }
        public async Task<List<Attendees>> GetAllAttendeesByEvent(int event_id)
        {
            var res = await _context.Attendees.Where(e=>e.events_id==event_id).ToListAsync<Attendees>();
            return res;
        }
        public async Task AddAttendee(Attendees attendee)
        {

            _context.Attendees.Add(attendee);
            var tsq = await _context.Events.FindAsync(attendee.events_id);
            tsq.Ticket_Sold_Quantity += 1;
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAttendee_ByPatch(int id, JsonPatchDocument attendee)
        {
            var odt = await _context.Attendees.FindAsync(id);
            if (odt != null)
            {
                attendee.ApplyTo(odt);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateAttendee_ByPut(Attendees attendee)
        {
            _context.Attendees.Update(attendee);                    
            await _context.SaveChangesAsync();
            
        }
        public async Task Delete_Attendee(int id)
        {
            var a = await _context.Attendees.FindAsync(id);
            var tsq = await _context.Events.FindAsync(a.events_id);
            tsq.Ticket_Sold_Quantity -= 1;
            await _context.SaveChangesAsync();
        }
    }

}
