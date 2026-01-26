using Core.Entities;

namespace API.Data.SeedData
{
    public class ConditionSeed
    {
        public static async Task SeedConditionData(DataContext context)
        {
            // Step 1: Check if data already exists to prevent duplication.
            if (context.Conditions.Any())
            {
                return; // Database has been seeded
            }

            // Step 2: Create a list of new data to add.
            var conditions = new List<Condition>
            {
                new Condition
                {
                    Name = "Pokémon"
                },
                new Condition
                {
                    Name = "Yu-Gi-Oh!"
                },
                new Condition
                {
                    Name = "Magic The Gathering"
                },
                new Condition
                {
                    Name = "One Piece"
                },
                new Condition
                {
                    Name = "Duel Masters"
                },
            };

            context.Conditions.AddRange(conditions);
            await context.SaveChangesAsync();
        }
    }
}
