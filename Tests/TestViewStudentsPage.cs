using StudentsWebDriverPomHomework.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsWebDriverPomHomework.Tests
{
    internal class TestViewStudentsPage : BaseTest
    {

        private ViewStudentsPage view_students_page;

        [SetUp]
        public void Setup()
        {
            this.view_students_page = new ViewStudentsPage(driver);
        }

        [Test]
        public void Test_ViewStudentsPage_Content()
        {
            // Instantiate the “ViewStudentsPage” class, open the “View Students” page and check its title and heading:
            view_students_page.Open();

            Assert.That(view_students_page.GetPageTitle(), Is.EqualTo("Students"));

            Assert.That(view_students_page.GetPageHeading(), Is.EqualTo("Registered Students"));

            //Invoke the GetRegisteredStudents() method to get all students on the page:
            var students = view_students_page.GetStudentsList();

            // Assert that each student record contains “(” and finishes with “)”:
            foreach(var st in students )
            {
                Assert.That(st.IndexOf("("), Is.GreaterThan(0));
                Assert.That(st.LastIndexOf(")"), Is.EqualTo(st.Length-1));
            }
        }

        [Test]
        public void Test_ViewStudentsPage_Links()
        {
            view_students_page.Open();
            view_students_page.LinkHomePage.Click();
            Assert.That(new HomePage(driver).IsOpen());

            view_students_page.Open();
            view_students_page.LinkViewStudentsPage.Click();
            Assert.That(new ViewStudentsPage(driver).IsOpen());

            view_students_page.Open();
            view_students_page.LinkAddStudentsPage.Click();
            Assert.That(new AddStudentPage(driver).IsOpen());
        }

    }
}
