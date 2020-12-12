using Microsoft.EntityFrameworkCore;
using Z01.Models;
using Z01.Models.Data;
using Z01.Models.Entities;

namespace Z01.Data
{
    public class PlannerContext : DbContext
    {
        public PlannerContext (DbContextOptions<PlannerContext> options)
            : base(options)
        {
        }
        public DbSet<NewActivityModel> Activities { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<ClassGroup> ClassGroups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}