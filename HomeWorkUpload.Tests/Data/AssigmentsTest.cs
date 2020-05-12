using System.Threading.Tasks;
using FluentAssertions;
using HomeWorkUpload.Data;
using HomeWorkUpload.Tests.Fixtures;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace HomeWorkUpload.Tests.Data
{
    [TestFixture]
    public class AssigmentsTest : DbTestBase
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
        public async Task TestAssigmentCreationAsync()
        {
            var assigment = await DataFixture.CreateAssigmentAsync(DbContext);

            var stored = await DbContext.Assigments.FirstOrDefaultAsync(t => t.Name.Equals(assigment.Name));

            stored.Should().BeEquivalentTo(assigment);
        }

        [Test]
        public async Task TestAssigmentDeletionAsync()
        {
            var assigment = await DataFixture.CreateAssigmentAsync(DbContext);

            var assigmentId = assigment.Id;
            DbContext.Assigments.Remove(assigment);
            await DbContext.SaveChangesAsync();

            var stored = await DbContext.Assigments.FindAsync(assigmentId);

            stored.Should().BeNull();
        }

        [Test]
        public async Task TestAssigmentUpdateAsync()
        {
            var assigment = await DataFixture.CreateAssigmentAsync(DbContext);

            assigment.CopyEmail = "modified!";

            DbContext.Assigments.Update(assigment);
            await DbContext.SaveChangesAsync();

            var stored = await DbContext.Assigments.FindAsync(assigment.Id);

            stored.Should().BeEquivalentTo(assigment);
        }
    }
}