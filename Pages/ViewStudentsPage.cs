using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsWebDriverPomHomework.Pages
{
    internal class ViewStudentsPage : BasePage
    {
        public override string PageUrl => "https://studentregistry.softuniqa.repl.co/students";

        public ViewStudentsPage(WebDriver driver) : base(driver)
        {
        }

        private ReadOnlyCollection<IWebElement> ListItemsStudents => driver.FindElements(By.CssSelector("body > ul > li"));

        public string[] GetStudentsList() { 
            var elementsStudents = this.ListItemsStudents.Select(s => s.Text).ToArray();
            return elementsStudents;
        }

    }
}
