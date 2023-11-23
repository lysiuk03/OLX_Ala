
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OLX_Ala.Data
{
    public class AlaOlxDbContext : IdentityDbContext<User>
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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Announcement>()
                .Property(a => a.Price)
                .HasColumnType("decimal(18,2)");

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

            
        }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
