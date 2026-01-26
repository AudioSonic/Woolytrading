using System.Collections.Generic;
using System.Linq;
using Core.Entities;

namespace API.Data.SeedData
{
    public class CategorySeed
    {
        public static async Task SeedCategoryData(DataContext context)
        {
            // Step 1: Check if data already exists to prevent duplication.
            if (context.Categories.Any())
            {
                return; // Database has been seeded
            }

            // Step 2: Create a list of new data to add.
            var categories = new List<Category>
            {
                new Category
                {
                    Name = "Pokémon"
                },
                new Category
                {
                    Name = "Yu-Gi-Oh!"
                },
                new Category
                {
                    Name = "Magic The Gathering"
                },
                new Category
                {
                    Name = "One Piece"
                },
                new Category
                {
                    Name = "Duel Masters"
                },
            };

            context.Categories.AddRange(categories);
            await context.SaveChangesAsync();
        }
    }
}
