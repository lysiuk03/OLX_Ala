using Microsoft.EntityFrameworkCore;
using DataAccess.Data.Entities;

namespace OLX_Ala.Data
{
    public class AlaOlxDbContext : DbContext
    {
        public AlaOlxDbContext()
        {
            
        }
        public AlaOlxDbContext(DbContextOptions options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
           // optionsBuilder.UseSqlServer("");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Announcement>()
      .Property(a => a.Price)
      .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<Category>().HasData(new[]
            {
                new Category() {Id=1, Name="Help"},
                new Category() {Id=2, Name="Children's world"},
                new Category() {Id=3, Name="Real estate"},
                new Category() {Id=4, Name="Car"},
                new Category() {Id=5, Name="Spare parts"},
                new Category() {Id=6, Name="Work"},
                new Category() {Id=7, Name="Animals"},
                new Category() {Id=8, Name="House and garden"},
                new Category() {Id=9, Name="Electronics"},
                new Category() {Id=10, Name="Business and services"},
                new Category() {Id=11, Name="Rent and hire"},
                new Category() {Id=12, Name="Fashion and style"},
                new Category() {Id=13, Name="Hobbies, recreation and sports"}
            });
            modelBuilder.Entity<Region>().HasData(new[]
           {
                new Region() {Id=1, Name="Vinnitsa"},
                new Region() {Id=2, Name="Dnipro"},
                new Region() {Id=3, Name="Donetsk"},
                new Region() {Id=4, Name="Zhytomyr"},
                new Region() {Id=5, Name="Zaporizhzhia"},
                new Region() {Id=6, Name="Ivano-Frankivsk"},
                new Region() {Id=7, Name="Kyiv"},
                new Region() {Id=8, Name="Kropyvnytskyi"},
                new Region() {Id=9, Name="Luhansk"},
                new Region() {Id=10, Name="Lutsk"},
                new Region() {Id=11, Name="Lviv"},
                new Region() {Id=12, Name="Mykolaiv"},
                new Region() {Id=13, Name="Odesa"},
                new Region() {Id=14, Name="Poltava"},
                new Region() {Id=15, Name="Rivne"},
                new Region() {Id=16, Name="Sumy"},
                new Region() {Id=17, Name="Ternopil"},
                new Region() {Id=18, Name="Uzhhorod"},
                new Region() {Id=19, Name="Kharkiv"},
                new Region() {Id=20, Name="Kherson"},
                new Region() {Id=21, Name="Khmelnytskyi"},
                new Region() {Id=22, Name="Cherkasy"},
                new Region() {Id=23, Name="Chernivtsi"},
                new Region() {Id=24, Name="Chernihiv"}
            });

            modelBuilder.Entity<Announcement>().HasData(new[]
            {
                new Announcement() {Id=1, Name="Cat", Price=30,InStock=true, ImageURL="https://ireland.apollo.olxcdn.com/v1/files/nska4awhvbf5-UA/image",CategoryId=7, RegionId=15,Description="The kitten is looking for a family!",ContactName="Dasha",Phone="0685062142"},
                new Announcement() {Id=2, Name="Dog", Price=20,InStock=false, ImageURL="https://ireland.apollo.olxcdn.com/v1/files/giu39aqm2mrq1-UA/image",CategoryId=7, RegionId=13,Description="The puppy is looking for a family!",ContactName="Dasha",Phone="0683552144"},
                new Announcement() {Id=3, Name="Rat", Price=10,InStock=true, ImageURL="https://ireland.apollo.olxcdn.com/v1/files/1xbhsqtzmnmo-UA/image",CategoryId=7, RegionId=16,Description="The rat is looking for a family!",ContactName="Dasha",Phone="0685062142"}
            });
        }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Region> Regions { get; set; }
    }
}
