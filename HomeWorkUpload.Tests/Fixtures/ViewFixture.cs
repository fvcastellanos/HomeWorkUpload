using HomeWorkUpload.Model.Views;

namespace HomeWorkUpload.Tests.Fixtures
{
    public static class ViewFixture
    {
        public static AssigmentView BuildAssigmentView(string name)
        {
            return new AssigmentView
            {
                Name = name,
                Description = "Test Assigment",
                Email = "email@mail.com",
                CopyEmail = "copyEmail@mail.com"
            };
        }

        public static AssigmentView BuildAssigmentView()
        {
            return BuildAssigmentView("Test Assigment");
        }
    }
}