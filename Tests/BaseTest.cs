using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace StudentsWebDriverPomHomework.Tests
{
    public class BaseTest
    {
        // a driver for the handling of requests.
        protected WebDriver driver;

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--headless");

            this.driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }

    }
}