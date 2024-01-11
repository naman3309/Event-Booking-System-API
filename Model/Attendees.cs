namespace Event_Booking_System_API.Model
{
    public enum Gender
    {
        male= 0,female=1,others = 2
    }
    public class Attendees
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int age { get; set; }
        public Gender gender { get; set; }
        public Events events { get; set; }


    }

}

