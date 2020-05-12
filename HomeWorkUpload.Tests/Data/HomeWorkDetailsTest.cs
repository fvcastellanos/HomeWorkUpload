using System.Threading.Tasks;
using HomeWorkUpload.Data;
using HomeWorkUpload.Tests.Fixtures;
using NUnit.Framework;

namespace HomeWorkUpload.Tests.Data
{
    [TestFixture]
    public class HomeWorkDetailsTest : DbTestBase
    {
        [SetUp]
        public void SetUp()
        {
            StartTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            RollBackTransaction();
        }

        [Test]
        public async Task TestHomeWorkDetailCreation()
        {
            var detail = await CreateHomeWorkDetailAsync();
        }

        private async Task<HomeWorkDetail> CreateHomeWorkDetailAsync()
        {
            var assigment = await DataFixture.CreateAssigmentAsync(DbContext);
            var homework = await DataFixture.CreateHomeWorkAsync(DbContext, assigment);
            return await DataFixture.CreateHomeWorkDetailAsync(DbContext, homework);
        }
    }
}