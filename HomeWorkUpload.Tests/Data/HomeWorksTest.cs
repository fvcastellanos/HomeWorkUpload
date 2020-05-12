using System.Threading.Tasks;
using FluentAssertions;
using HomeWorkUpload.Data;
using HomeWorkUpload.Tests.Fixtures;
using NUnit.Framework;

namespace HomeWorkUpload.Tests.Data
{
    [TestFixture]
    public class HomeWorksTest : DbTestBase
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
        public async Task TestHomeWorkCreationAsync()
        {
            var homeWork = await CreateHomeWorkAsync();

            var stored = await DbContext.HomeWorks.FindAsync(homeWork.Id);

            stored.Should().BeEquivalentTo(homeWork);
        }

        [Test]
        public async Task TestHomeWorkDeletion()
        {
            var homeWork = await CreateHomeWorkAsync();

            DbContext.HomeWorks.Remove(homeWork);
            await DbContext.SaveChangesAsync();

            var stored = await DbContext.HomeWorks.FindAsync(homeWork.Id);

            stored.Should().BeNull();
        }

        [Test]
        public async Task TestHomeWorkUpdateAsync()
        {
            var homeWork = await CreateHomeWorkAsync();
            homeWork.Description = "modified!";

            DbContext.HomeWorks.Update(homeWork);
            DbContext.SaveChanges();

            var stored = await DbContext.HomeWorks.FindAsync(homeWork.Id);

            stored.Should().BeEquivalentTo(homeWork);

        }

        // ------------------------------------------------------------------------------------------

        private async Task<HomeWork> CreateHomeWorkAsync()
        {
            var assigment = await DataFixture.CreateAssigmentAsync(DbContext);
            return await DataFixture.CreateHomeWorkAsync(DbContext, assigment);
        }
    }
}