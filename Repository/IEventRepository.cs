using Event_Booking_System_API.Model;

namespace Event_Booking_System_API.Repository
{
    public interface IEventRepository
    {
        Task<List<Events>> GetAllEvents();
        Task<Events> GetEventsByIdAsync(int id);
        Task<int> GetEventIdByName(string name);
        Task<int> AddEvent(Events _event);
    }
}