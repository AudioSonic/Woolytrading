using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ///Implementierung der Datenbankverbindung
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            
            //Die Services werden dem Container hinzugefügt. Alle Tabellen werden in
            //DataContext gespeichert
            builder.Services.AddDbContext<DataContext>(options =>
            {
                //EF Core wird angewiesen, SQL Server zu verwenden
                options.UseSqlServer(connectionString);
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
