using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models.Interfaces;
using Async_Inn_Management_System.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();


            string connString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services
                .AddDbContext<AsyncInnDbContext>
                (opions => opions.UseSqlServer(connString));


            builder.Services.AddTransient<IHotel, HotelServices>();
            builder.Services.AddTransient<IHotelRoom, HotelRoomServices>();
            builder.Services.AddTransient<IRoom, RoomServices>();
            builder.Services.AddTransient<IAmenity, AmenityServices>();

            var app = builder.Build();

            app.MapControllers();

            
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}