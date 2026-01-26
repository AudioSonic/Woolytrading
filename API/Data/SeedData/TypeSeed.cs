using Core.Entities;

namespace API.Data.SeedData
{
    public class TypeSeed
    {
        public static async Task SeedTypeData(DataContext context)
        {
            // Step 1: Check if data already exists to prevent duplication.
            if (context.Types.Any())
            {
                return; // Database has been seeded
            }

            // Step 2: Create a list of new data to add.
            var types = new List<Types>
    {
        new Types
        {
            Name = "Card"
        },
        new Types
        {
            Name = "Booster"
        },
        new Types
        {
            Name = "Deck"
        },
        new Types
        {
            Name = "Structure Deck"
        },
        new Types
        {
            Name = "Collection"
        },
    };

            context.Types.AddRange(types);
            await context.SaveChangesAsync();
        }
    }
}
