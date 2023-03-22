using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsWebDriverPomHomework.Pages
{
    public class HomePage : BasePage
    {
        
        public HomePage(WebDriver driver) : base(driver)
        {

        }

        public override string PageUrl => "https://studentregistry.softuniqa.repl.co/";

        public IWebElement ElementStudentsCount => driver.FindElement(By.CssSelector("body > p > b"));

        public string GetStudentsCount()
        {
            return ElementStudentsCount.Text;
        }

    }
}
