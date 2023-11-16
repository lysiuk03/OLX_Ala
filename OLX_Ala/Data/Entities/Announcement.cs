namespace OLX_Ala.Data.Entities
{
    public class Announcement
    {
        public int Id { get; set; }
        //[Required]
        //[StringLength(100)]
        public string Name { get; set; }
        // [Range(0,int.MaxValue)]
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        // [Url]
        public string? ImageURL { get; set; }
        public int CategoryId { get; set; }
        public int RegionId { get; set; }
        // [Range(0, 100)]
        public int? Discount { get; set; }
        //[StringLength(1000,MinimumLength =10)]
        public string? Description { get; set; }
        //[Required]
        //[StringLength(100)]
        public string ContactName { get; set; }
        //[Phone]
        public string Phone { get; set; }

        public Category? category { get; set; }
        public Region? region { get; set; }
    }
}
