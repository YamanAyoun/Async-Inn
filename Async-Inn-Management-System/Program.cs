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

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Async_Inn_Management_System",
                    Version = "v1",
                });
            });

            var app = builder.Build();

            app.UseSwagger(aptions =>
            {
                aptions.RouteTemplate = "/api/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(aptions =>
            {
                aptions.SwaggerEndpoint("/api/v1/swagger.json", "Async_Inn_Management_System");
                aptions.RoutePrefix = "docs";
            });

            app.MapControllers();

            
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}