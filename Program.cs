using Event_Booking_System_API;
using Event_Booking_System_API.Model;
using Event_Booking_System_API.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IEventRepository,EventsRepository>();
builder.Services.AddTransient<IAttendeesRepository,AttendeesRepository>();
builder.Services.AddDbContext<APIDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Event_Mgt_DB")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
