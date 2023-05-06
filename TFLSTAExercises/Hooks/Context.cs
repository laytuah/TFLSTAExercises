using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TFLSTAExercises.Hooks
{
    public class Context
    {
        public IWebDriver driver;
        public string baseUrl = "https://tfl.gov.uk/";

        public void LaunchTFLApplication()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseUrl);
        }

        public void CloseTFLApplication()
        {
            driver.Quit();
        }
    }
}
