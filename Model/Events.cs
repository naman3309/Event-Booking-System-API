namespace Event_Booking_System_API.Model
{
    public enum EventKind
    {
        PG13 = 0,
        Adult = 1,
        All = 2
    }

    public class Events
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public EventKind EventType { get; set; }
        public int Totalseats { get; set; }
        public string EventVenue {  get; set; }
        public DateOnly EventDate { get; set; }
        public TimeOnly EventTime { get; set; }
        public List<Attendees> attendees { get; set; }

    }
}
