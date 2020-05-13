using System.Threading.Tasks;
using HomeWorkUpload.Data;

namespace HomeWorkUpload.Tests.Fixtures
{
    public static class DataFixture
    {
        public static Assigment BuildAssigment(string name)
        {
            return new Assigment()
            {
                Name = name,
                Description = "Test Assigment",
                Email = "email@mail.com",
                CopyEmail = "copyEmail@mail.com"
            };
        }

        public static Assigment BuildAssigment()
        {
            return BuildAssigment("Test Assigment");
        }

        public static HomeWork BuildHomeWork()
        {
            return new HomeWork()
            {
                Name = "Test Homework",
                Description = "Test HomeWork",                
            };
        }

        public static HomeWorkDetail BuildHomeWorkDetail()
        {
            return new HomeWorkDetail()
            {
                ImageUrl = "image path"
            };
        }

        public static async Task<Assigment> CreateAssigmentAsync(ApplicationContext dbContext)
        {
            var assigment = BuildAssigment();

            await dbContext.AddAsync(assigment);
            await dbContext.SaveChangesAsync();

            return assigment;
        }

        public static async Task<HomeWork> CreateHomeWorkAsync(ApplicationContext dbContext, Assigment assigment)
        {
            var homeWork = BuildHomeWork();

            homeWork.Assigment = assigment;

            await dbContext.HomeWorks.AddAsync(homeWork);
            await dbContext.SaveChangesAsync();

            return homeWork;
        }

        public static async Task<HomeWorkDetail> CreateHomeWorkDetailAsync(ApplicationContext dbContext, HomeWork homeWork)
        {
            var detail = BuildHomeWorkDetail();
            detail.HomeWork = homeWork;

            await dbContext.HomeWorkDetails.AddAsync(detail);
            await dbContext.SaveChangesAsync();

            return detail;
        }

    }
}