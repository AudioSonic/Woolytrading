using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; } = 0;
        public string? ImageUrl { get; set; }
        public int? CategoryId { get; set; }
        public int? ConditionId { get; set; }
        public int? RarityId { get; set; }
        public int? TypesId { get; set; }
        public Category? Category { get; set; }
        public Condition? Condition { get; set; }
        public Rarity? Rarity { get; set; }
        public Types? Type { get; set; }
    }
}
