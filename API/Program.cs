using API.Data;
using Microsoft.EntityFrameworkCore;
using API.Data.SeedData;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
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

            // --- Add Seeding Logic Here ---
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<DataContext>();
                await context.Database.MigrateAsync(); // Applies any pending migrations
                
                await CategorySeed.SeedCategoryData(context);
                await ConditionSeed.SeedConditionData(context);
                await RaritySeed.SeedRarityData(context);
                await TypeSeed.SeedTypeData(context);
                await ProductSeed.SeedProductData(context);

            }

            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred during migration or seeding.");
            }
            // --- End of Seeding Logic ---

            app.Run();
        }
    }
}
