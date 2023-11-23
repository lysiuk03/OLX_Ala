﻿namespace DataAccess.Data.Entities
{
    public class Announcement
    {
        public int Id { get; set; }

        public string? UserId { get; set; }
        
        public string Name { get; set; }
        
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        
        public string? ImageURL { get; set; }
        public int CategoryId { get; set; }
        public int RegionId { get; set; }
        
        public int? Discount { get; set; }
        
        public string? Description { get; set; }
        
        public string ContactName { get; set; }
        
        public string Phone { get; set; }

        public Category? category { get; set; }
        public Region? region { get; set; }
        public User? user { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
