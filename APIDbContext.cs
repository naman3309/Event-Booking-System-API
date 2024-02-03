using Event_Booking_System_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Event_Booking_System_API
{
    public class APIDbContext:DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options):base(options) { }
            public DbSet<Events> Events { get; set; }
            public DbSet<Attendees> Attendees { get; set; }
            
            public DbSet<Booking> Bookings { get; set; }

    }

}

