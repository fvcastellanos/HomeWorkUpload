using Microsoft.EntityFrameworkCore;

namespace HomeWorkUpload.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Assigment> Assigments { get; set; }
        public DbSet<HomeWork> HomeWorks { get; set; }
        public DbSet<HomeWorkDetail> HomeWorkDetails { get; set; }
        
        public ApplicationContext(DbContextOptions<ApplicationContext> dbContext) : base(dbContext)
        {
            // db context initialize
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assigment>();
            modelBuilder.Entity<HomeWork>();
            modelBuilder.Entity<HomeWorkDetail>();
        }        
    }
}