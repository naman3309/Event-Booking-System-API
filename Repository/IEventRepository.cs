using Event_Booking_System_API.Model;
using Microsoft.AspNetCore.JsonPatch;

namespace Event_Booking_System_API.Repository
{
    public interface IEventRepository
    {
        Task<List<Events>> GetAllEvents();
        Task<Events> GetEventsByIdAsync(int id);
        Task<Events> GetEventIdByName(string name);
        Task<int> Get_seats_left_by_Id(int id);
        Task<DateTime> Get_Date_Time_by_Id(int id);
        Task<int> AddEvent(Events _event);

        Task Update_event_details(int id, JsonPatchDocument body);
        Task Delete_Event(int id);
    }
}