using Microsoft.EntityFrameworkCore;
using SmartGoalApp.Models;

namespace SmartGoalApp.Persistence
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
             
        }

        public DbSet<Folder> Folders { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
