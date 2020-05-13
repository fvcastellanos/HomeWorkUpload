using HomeWorkUpload.Model.Views;

namespace HomeWorkUpload.Tests.Fixtures
{
    public static class ViewFixture
    {
        public static AssigmentView BuildAssigmentView()
        {
            return new AssigmentView
            {
                Name = "Test Assigment",
                Description = "Test Assigment",
                Email = "email@mail.com",
                CopyEmail = "copyEmail@mail.com"
            };
        }
    }
}