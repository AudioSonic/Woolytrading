using Core.Entities;

namespace API.Data.SeedData
{
    public class RaritySeed
    {
        public static async Task SeedRarityData(DataContext context)
        {
            // Step 1: Check if data already exists to prevent duplication.
            if (context.Rarities.Any())
            {
                return; // Database has been seeded
            }

            // Step 2: Create a list of new data to add.
            var rarities = new List<Rarity>
    {
        new Rarity
        {
            Name = "Common"
        },
        new Rarity
        {
            Name = "Uncommon"
        },
        new Rarity
        {
            Name = "Rare"
        },
        new Rarity
        {
            Name = "Ultra Rare"
        }
    };

            context.Rarities.AddRange(rarities);
            await context.SaveChangesAsync();
        }
    }
}
