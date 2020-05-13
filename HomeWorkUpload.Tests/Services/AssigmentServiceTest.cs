using System.Collections.Generic;
using FluentAssertions;
using HomeWorkUpload.Data;
using HomeWorkUpload.Model.Views;
using HomeWorkUpload.Services;
using HomeWorkUpload.Tests.Fixtures;
using Moq;
using Moq.EntityFrameworkCore;
using NUnit.Framework;

namespace HomeWorkUpload.Tests.Services
{
    [TestFixture]
    public class AssigmentServiceTest : ServiceTestBase
    {

        private AssigmentService _assigmentService;

        [SetUp]
        public void SetUp()
        {
            _assigmentService = new AssigmentService(DbContextMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void TestGetAssigments()
        {
            DbContextMock.Setup(context => context.Assigments).ReturnsDbSet(BuildAssigmentList());
            var assigments = _assigmentService.GetAssigments();

            var expected = BuildAssigmentViewList();

            assigments.Should()
                .BeEquivalentTo(expected);

            DbContextMock.Verify(context => context.Assigments);
        }

        // --------------------------------------------------------------------------------------------------------

        private static IEnumerable<Assigment> BuildAssigmentList()
        {
            return new List<Assigment>()
            {
                DataFixture.BuildAssigment()
            };
        }

        private static IEnumerable<AssigmentView> BuildAssigmentViewList()
        {
            return new List<AssigmentView>()
            {
                ViewFixture.BuildAssigmentView()
            };
        }
    }
}