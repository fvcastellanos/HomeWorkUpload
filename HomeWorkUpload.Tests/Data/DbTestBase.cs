using HomeWorkUpload.Data;
using Microsoft.EntityFrameworkCore;

namespace HomeWorkUpload.Tests.Data
{
    public class DbTestBase
    {
        protected ApplicationContext DbContext { get; }

        private DbContextOptions<ApplicationContext> _contextOptions { get; }

        protected DbTestBase()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            _contextOptions = optionsBuilder.UseMySQL("server=localhost;database=homework_upload;user=root;password=r00t")
                .Options;

            DbContext = new ApplicationContext(_contextOptions);

            Seed();
        }

        protected void StartTransaction()
        {
            DbContext.Database.BeginTransaction();
        }

        protected void RollBackTransaction()
        {
            DbContext.Database.RollbackTransaction();
        }

        private void Seed()
        {
            using (var context = new ApplicationContext(_contextOptions))
            {
                context.Database.EnsureCreated();
            }
        }
    }
}