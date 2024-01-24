using Event_Booking_System_API.Model;
using Microsoft.AspNetCore.JsonPatch;

namespace Event_Booking_System_API.Repository
{
    public interface IAttendeesRepository
    {
        Task<List<Attendees>> GetAll();
        Task<List<Attendees>> GetAllAttendeesByEvent(int event_id);
        Task AddAttendee(Attendees attendee);
        Task UpdateAttendee_ByPatch(int id, JsonPatchDocument attendee);
        Task UpdateAttendee_ByPut(Attendees attendee);
        Task Delete_Attendee(int id);

    }
}