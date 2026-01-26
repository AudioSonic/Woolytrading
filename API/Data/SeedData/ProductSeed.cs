using System.Collections.Generic;
using System.Linq;
using Core.Entities;

namespace API.Data.SeedData
{
    public class ProductSeed
    {
        public static async Task SeedProductData(DataContext context)
        {
            // Step 1: Check if data already exists to prevent duplication.
            if (context.Products.Any())
            {
                return; // Database has been seeded
            }

            // Step 2: Create a list of new data to add.
            var products = new List<Product>
            {
                new Product
                {
                    Name = "Glurak",
                    Description = "Leider nicht so cool wie Bisaflor",
                    Price = 2500, // Storing price in cents is a best practice
                    ImageUrl = "/images/products/glurak.png",
                    CategoryId = 1,
                    ConditionId = 2,
                    RarityId = 3,
                    TypesId = 1
                },
                new Product
                {
                    Name = "Yugi",
                    Description = "Whats wrong with his hair!?",
                    Price = 999, // Storing price in cents is a best practice
                    ImageUrl = "/images/products/Yugi.png",
                    CategoryId = 2,
                    ConditionId = 5,
                    RarityId = 2,
                    TypesId = 3
                },
                new Product
                {
                    Name = "Schwarzer Magier",
                    Description = "Schwarz ist dunkler als dunkel",
                    Price = 2500, // Storing price in cents is a best practice
                    ImageUrl = "/images/products/SM.png",
                    CategoryId = 2,
                    ConditionId = 4,
                    RarityId = 1,
                    TypesId = 1
                },
                new Product
                {
                    Name = "Pikachu",
                    Description = "Miauz genau!",
                    Price = 2500, // Storing price in cents is a best practice
                    ImageUrl = "/images/products/Pikachu.png",
                    CategoryId = 1,
                    ConditionId = 2,
                    RarityId = 3,
                    TypesId = 1
                },
                new Product
                {
                    Name = "Ruffy",
                    Description = "Gum Gum Kanone",
                    Price = 2500, // Storing price in cents is a best practice
                    ImageUrl = "/images/products/Ruffy.png",
                    CategoryId = 4,
                    ConditionId = 4,
                    RarityId = 3,
                    TypesId = 5
                },
            };

            context.Products.AddRange(products);
            await context.SaveChangesAsync();
        }
    }
}
