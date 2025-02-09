using Microsoft.EntityFrameworkCore;
using Model;

namespace DataAccess.Data
{
    public class FarmWiseDBContext : DbContext
    {
        public FarmWiseDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Crop> Crops { get; set; }
        public DbSet<SoilData> SoilDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User-Crop Relationship
            modelBuilder.Entity<Crop>()
                .HasOne(c => c.User)
                .WithMany(u => u.Crops)
                .HasForeignKey(c => c.UserId)  
                .OnDelete(DeleteBehavior.Cascade);

            // SoilData-Crop Relationship
            modelBuilder.Entity<Crop>()
                .HasOne(c => c.SoilData)
                .WithMany(s => s.Crops)
                .HasForeignKey(c => c.SoilDataId)  
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
