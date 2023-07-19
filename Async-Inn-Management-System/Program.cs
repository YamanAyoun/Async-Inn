using Async_Inn_Management_System.Data;
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


            var app = builder.Build();

            app.MapControllers();


            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}