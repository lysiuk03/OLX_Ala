﻿using DataAccess.Data.Entities;

namespace OLX_Ala.Models
{
    public class CreateAnnouncementModel
    {


        public string Name { get; set; }

        public decimal Price { get; set; }
        public bool InStock { get; set; }

        public IFormFile? ImageFile { get; set; }
        public int CategoryId { get; set; }
        public int RegionId { get; set; }

        public int? Discount { get; set; }

        public string? Description { get; set; }

        public string ContactName { get; set; }

        public string Phone { get; set; }

    }
}
