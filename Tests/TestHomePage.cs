using StudentsWebDriverPomHomework.Pages;

namespace StudentsWebDriverPomHomework.Tests
{
    public class TestHomePage : BaseTest
    {

        private HomePage page;

        [SetUp]
        public void Setup()
        {
            this.page = new HomePage(driver);
        }

        [Test]
        public void Test_HomePage_Content()
        {
            page.Open();

            //Assert the page title is correct (window title):
            Assert.That(page.GetPageTitle(), Is.EqualTo("MVC Example"));

            //Assert the page heading is correct (the top heading at the start of the page):
            Assert.That(page.GetPageHeading(), Is.EqualTo("Students Registry"));

            //Invoke the GetStudentsCount() method- it should not throw any errors:
            Assert.That(page.GetStudentsCount(), Is.Not.Empty);

        }

        [Test]
        public void Test_HomePage_Links()
        {
            page.Open();
            page.LinkHomePage.Click();
            Assert.That(new HomePage(driver).IsOpen());

            page.Open();
            page.LinkViewStudentsPage.Click();
            Assert.That(new ViewStudentsPage(driver).IsOpen());

            page.Open();
            page.LinkAddStudentsPage.Click();
            Assert.That(new AddStudentPage(driver).IsOpen());
        }

    }
}