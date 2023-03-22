using OpenQA.Selenium.Chrome;
using StudentsWebDriverPomHomework.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsWebDriverPomHomework.Tests
{
    internal class TestAddStudentsPage : BaseTest
    {
        private AddStudentPage add_student_page;

        [SetUp]
        public void Setup()
        {
            this.add_student_page = new AddStudentPage(driver);
        }



        [Test]
        public void Test_TestAddStudentPage_Content()
        {
            add_student_page.Open();

            //Assert the page title and heading are correct
            Assert.That(add_student_page.GetPageTitle(), Is.EqualTo("Add Student"));
            Assert.That(add_student_page.GetPageHeading(), Is.EqualTo("Register New Student"));

            //Assert the form fields are empty
            Assert.That(add_student_page.GetFieldStudentNameValue(), Is.Empty);
            Assert.That(add_student_page.GetFieldStudentNameValue(), Is.Empty);

            //Assert that the form button has a correct text
            Assert.That(add_student_page.GetButtonAddValue(), Is.EqualTo("Add"));

        }

        [Test]
        public void Test_TestAddStudentPage_Links()
        {
            add_student_page.Open();
            add_student_page.LinkHomePage.Click();
            Assert.That(new HomePage(driver).IsOpen());

            add_student_page.Open();
            add_student_page.LinkViewStudentsPage.Click();
            Assert.That(new ViewStudentsPage(driver).IsOpen());

            add_student_page.Open();
            add_student_page.LinkAddStudentsPage.Click();
            Assert.That(new AddStudentPage(driver).IsOpen());
        }

        [Test]
        public void Test_TestAddStudentPage_AddValidStudent()
        {
            add_student_page.Open();
            
            string name = "New student" + DateTime.Now.Ticks;
            string email = "email" + DateTime.Now.Ticks + "@email.com";
            string final_value = name + " (" + email + ")";

            add_student_page.AddStudent(name, email);

            var view_students_page = new ViewStudentsPage(driver);

            //Assert the “View Students” page is open
            Assert.That(view_students_page.IsOpen(), Is.True);

            //Assert the page contains the new student 
            Assert.That(view_students_page.GetStudentsList().Last<string>, Is.EqualTo(final_value));
        }

        [Test]
        public void Test_TestAddStudentPage_AddInvalidStudent()
        {
            add_student_page.Open();

            string name = "";
            string email = "";
            
            add_student_page.AddStudent(name, email);

            //Assert the “Add Student” page is still open
            Assert.That(new AddStudentPage(driver).IsOpen(), Is.True);

            //Assert that the error message contains the “Cannot add student” text
            Assert.That(add_student_page.GetErrorMsg(), Is.EqualTo("Cannot add student. Name and email fields are required!"));

        }

    }
}
