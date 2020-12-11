using Microsoft.EntityFrameworkCore;
using Z01.Models;
using Z01.Models.Data;

namespace Z01.Data
{
    public class PlannerContext : DbContext
    {
        public PlannerContext (DbContextOptions<PlannerContext> options)
            : base(options)
        {
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<NewActivityModel> Activities { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().ToTable("Rooms");
            modelBuilder.Entity<NewActivityModel>().ToTable("Activities");
        }
    }
}