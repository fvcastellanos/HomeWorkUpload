using HomeWorkUpload.Data;
using Moq;

namespace HomeWorkUpload.Tests.Services
{
    public abstract class ServiceTestBase
    {
        protected Mock<ApplicationContext> DbContextMock = new Mock<ApplicationContext>();

    }
}