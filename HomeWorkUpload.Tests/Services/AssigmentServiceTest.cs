using System.Collections.Generic;
using FluentAssertions;
using HomeWorkUpload.Data;
using HomeWorkUpload.Model.Views;
using HomeWorkUpload.Services;
using HomeWorkUpload.Tests.Fixtures;
using Microsoft.Extensions.Logging;
using Moq.EntityFrameworkCore;
using LanguageExt.UnitTesting;
using NUnit.Framework;
using System;

namespace HomeWorkUpload.Tests.Services
{
    [TestFixture]
    public class AssigmentServiceTest : ServiceTestBase
    {

        private AssigmentService _assigmentService;

        [SetUp]
        public void SetUp()
        {            
            _assigmentService = new AssigmentService(DbContextMock.Object, new LoggerFactory());
        }

        [Test]
        public void TestGetAssigments()
        {
            DbContextMock.Setup(context => context.Assigments).ReturnsDbSet(BuildAssigmentList());

            var result = _assigmentService.GetAssigments();

            var expected = BuildAssigmentViewList();

            result.ShouldBeRight(right => 
                right.Should().BeEquivalentTo(expected));

            DbContextMock.Verify(context => context.Assigments);
        }

        [Test]
        public void TestGetAssigmentsThrowError()
        {
            DbContextMock.Setup(context => context.Assigments).Throws(new Exception("expected exception"));

            var result = _assigmentService.GetAssigments();

            result.ShouldBeLeft(left => 
                left.Should().Be("can't get assigment list"));

            DbContextMock.Verify(context => context.Assigments);
        }

        [Test]
        public void TestAddExistingAssigment()
        {
            var assigmentName = "test";
            var assigmentView = ViewFixture.BuildAssigmentView(assigmentName);
            var assigment = DataFixture.BuildAssigment(assigmentName);

            var expectedError = String.Format("Assigment with name: {0} already exists", assigmentView.Name);

            DbContextMock.Setup(context => context.Assigments).ReturnsDbSet(BuildAssigmentList(assigment));

            var result = _assigmentService.CreateAssigment(assigmentView);

            result.ShouldBeLeft(left => 
                left.Should().Be(expectedError));

            DbContextMock.Verify(context => context.Assigments);
        }

        [Test]
        public void TestAddAssigmentThrowsException()
        {
            var assigmentName = "test";
            var assigmentView = ViewFixture.BuildAssigmentView(assigmentName);

            var expectedError = string.Format("can't create assigment with name: {0}", assigmentView.Name);

            DbContextMock.Setup(context => context.Assigments).ReturnsDbSet(new List<Assigment>());
            DbContextMock.Setup(context => context.SaveChanges()).Throws(new Exception("expected exception"));

            var result = _assigmentService.CreateAssigment(assigmentView);

            result.ShouldBeLeft(left => 
                left.Should().Be(expectedError));

            DbContextMock.Verify(context => context.Assigments);
            DbContextMock.Verify(context => context.SaveChanges());
        }

        [Test]
        public void TestAddAssigment()
        {
            var assigmentName = "test";
            var assigmentView = ViewFixture.BuildAssigmentView(assigmentName);

            DbContextMock.Setup(context => context.Assigments).ReturnsDbSet(new List<Assigment>());

            var result = _assigmentService.CreateAssigment(assigmentView);

            result.ShouldBeRight(right => 
                right.Should().BeEquivalentTo(assigmentView));

            DbContextMock.Verify(context => context.Assigments);
            DbContextMock.Verify(context => context.SaveChanges());
        }

        // --------------------------------------------------------------------------------------------------------

        private static IEnumerable<Assigment> BuildAssigmentList(Assigment assigment)
        {
            return new List<Assigment>()
            {
                assigment
            };
        }

        private static IEnumerable<Assigment> BuildAssigmentList()
        {
            return BuildAssigmentList(DataFixture.BuildAssigment());
        }

        private static IEnumerable<AssigmentView> BuildAssigmentViewList(AssigmentView assigmentView)
        {
            return new List<AssigmentView>()
            {
                assigmentView
            };
        }

        private static IEnumerable<AssigmentView> BuildAssigmentViewList()
        {
            return BuildAssigmentViewList(ViewFixture.BuildAssigmentView());
        }
        
    }
}