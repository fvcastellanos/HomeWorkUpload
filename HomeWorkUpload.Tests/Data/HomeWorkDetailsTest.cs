using System.Threading.Tasks;
using FluentAssertions;
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

            var stored = await DbContext.HomeWorkDetails.FindAsync(detail.Id);

            stored.Should().BeEquivalentTo(detail);
        }

        [Test]
        public async Task TestHomeWorkDetailUpdate()
        {
            var detail = await CreateHomeWorkDetailAsync();

            detail.ImageUrl = "updated!";

            DbContext.HomeWorkDetails.Update(detail);
            await DbContext.SaveChangesAsync();

            var stored = await DbContext.HomeWorkDetails.FindAsync(detail.Id);

            stored.Should().BeEquivalentTo(detail);
        }

        [Test]
        public async Task TestHomeWorkDetailDeletion()
        {
            var detail = await CreateHomeWorkDetailAsync();

            DbContext.HomeWorkDetails.Remove(detail);
            await DbContext.SaveChangesAsync();

            var stored = await DbContext.HomeWorkDetails.FindAsync(detail.Id);

            stored.Should().BeNull();
        }

        // ---------------------------------------------------------------------------------------------------

        private async Task<HomeWorkDetail> CreateHomeWorkDetailAsync()
        {
            var assigment = await DataFixture.CreateAssigmentAsync(DbContext);
            var homework = await DataFixture.CreateHomeWorkAsync(DbContext, assigment);
            return await DataFixture.CreateHomeWorkDetailAsync(DbContext, homework);
        }
    }
}