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

            builder.Services.AddSwaggerGen();
            
            //Die Services werden dem Container hinzugefügt. Alle Tabellen werden in
            //DataContext gespeichert
            builder.Services.AddDbContext<DataContext>(options =>
            {
                //EF Core wird angewiesen, SQL Server zu verwenden
                options.UseSqlServer(connectionString);
            });

            // Add services to the container.

            //Ermöglich die Nutzung der API und der Angular App auf localhost:4200
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });


            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowAngular");

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
