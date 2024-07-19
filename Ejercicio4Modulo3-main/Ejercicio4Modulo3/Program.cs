using Ejercicio4Modulo3.middlewaress;
using Ejercicio4Modulo3.Repository;
using Ejercicio4Modulo3.Servicios;
using Ejercicio4Modulo3.Servicios.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio4Modulo3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var cone = builder.Configuration.GetConnectionString("conexion");
            builder.Services.AddDbContext<Ejercicio4Modulo3Context>(opt => { opt.UseSqlServer(cone); });
 builder.Services.AddScoped<Iservicios, Servicio>();
            builder.Services.AddTransient<globalExpHand>();
            var app = builder.Build();
           
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            //  middleware
            app.UseMiddleware<globalExpHand>();

            app.MapControllers();

            app.Run();
        }
    }
}