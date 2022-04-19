using ComputerClub.Interfaces;
using ComputerClub.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerClub.EF
{
    public class ComputerClubContext : DbContext, IDbContext
    {
        public ComputerClubContext(DbContextOptions<ComputerClubContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Place> Places { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Place>()
                .HasOne(x => x.Equipment)
                .WithOne(x => x.Place)
                .HasForeignKey<Place>(x => x.EquipmentId);
        }
    }
}
