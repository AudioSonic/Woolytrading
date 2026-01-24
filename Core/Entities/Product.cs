using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int? CategoryId { get; set; }
        public int? ConditionId { get; set; }
        public int? RarityId { get; set; }
        public int? TypeId { get; set; }
        public Category? Category { get; set; }
        public Conditions? Condition { get; set; }
        public Rarities? Rarity { get; set; }
        public Types? Type { get; set; }
    }
}
