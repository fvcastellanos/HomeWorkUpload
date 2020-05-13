using Microsoft.EntityFrameworkCore;

namespace HomeWorkUpload.Data
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<Assigment> Assigments { get; set; }
        public virtual DbSet<HomeWork> HomeWorks { get; set; }
        public virtual DbSet<HomeWorkDetail> HomeWorkDetails { get; set; }

        public ApplicationContext()
        {
        }

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