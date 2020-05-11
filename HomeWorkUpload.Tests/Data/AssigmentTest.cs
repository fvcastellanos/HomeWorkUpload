using System.Threading.Tasks;
using HomeWorkUpload.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace HomeWorkUpload.Tests.Data
{
    public class AssigmentTest : DbTestBase
    {
        public AssigmentTest() : base()
        {
        }

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
        public void TestFooAsync()
        {
            var assigment = new Assigment()
            {
                Name = "Test Assigment",
                Description = "Test Assigment",
                Email = "email@mail.com",
                CopyEmail = "copyEmail@mail.com"
            };

            DbContext.Add(assigment);
            DbContext.SaveChanges();
        }
    }
}