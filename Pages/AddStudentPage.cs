using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsWebDriverPomHomework.Pages
{
    internal class AddStudentPage : BasePage
    {
        public override string PageUrl => "https://studentregistry.softuniqa.repl.co/add-student";

        private IWebElement FieldStudentName => driver.FindElement(By.Id("name"));
        private IWebElement FieldStudentEmail => driver.FindElement(By.Id("email"));
        private IWebElement ButtonAdd => driver.FindElement(By.CssSelector("body > form > button"));

        private IWebElement ElementErrorMsg => driver.FindElement(By.CssSelector("body > div"));

        public string GetFieldStudentNameValue()
        {
            return FieldStudentName.Text;
        }

        public string GetFieldStudentEmailValue()
        {
            return FieldStudentEmail.Text;
        }

        public string GetButtonAddValue()
        {
            return ButtonAdd.Text;
        }

        public AddStudentPage(WebDriver driver) : base(driver)
        {
        }

        public void AddStudent(string name, string email) 
        {
            this.FieldStudentName.SendKeys(name);
            this.FieldStudentEmail.SendKeys(email);
            this.ButtonAdd.Click();
        }
        public string GetErrorMsg()
        {
            var errorMessage = "";
            try  
            {
                    errorMessage = ElementErrorMsg.Text;
            }
            catch (Exception e)
            {
                // recover from exception
                errorMessage = "element not visible";
            }

            return errorMessage;
        }
    }
}
