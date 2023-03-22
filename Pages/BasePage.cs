using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsWebDriverPomHomework.Pages
{
    public class BasePage
    {
        protected readonly WebDriver driver;

        //public virtual string BaseUrl = "https://studentregistry.softuniqa.repl.co/";
        public virtual string PageUrl { get; }


        public BasePage(WebDriver driver)
        {
            this.driver = driver;
        }

        

        public IWebElement LinkHomePage => driver.FindElement(By.LinkText("Home"));
        public IWebElement LinkViewStudentsPage => driver.FindElement(By.LinkText("View Students"));
        public IWebElement LinkAddStudentsPage => driver.FindElement(By.LinkText("Add Student"));

        public IWebElement ElementPageHeading => driver.FindElement(By.CssSelector("body > h1"));


        // base methods for all pages

        public void Open()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }


        public string GetPageTitle()
        {
            return driver.Title;
        }

        
        public bool IsOpen()
        {
            return driver.Url == PageUrl;
        }

        public string GetPageHeading()
        {
            return ElementPageHeading.Text;
        }




    }
}
