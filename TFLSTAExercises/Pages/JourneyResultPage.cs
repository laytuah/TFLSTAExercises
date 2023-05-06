using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFLSTAExercises.Hooks;
using OpenQA.Selenium;
using System.Threading;

namespace TFLSTAExercises.Pages
{
    public class JourneyResultPage
    {
        Context context;
        public JourneyResultPage(Context _context)
        {
            context = _context;
        }

        By editJourneyLink = By.XPath("//span[text()='Edit journey']");
        By updateJourneyBtn = By.Id("plan-journey-button");
        By expectedConfirmationText = By.XPath("//a[@class='earlier jp-ajax-button']");
        By invalidJourneyResult = By.XPath("//div[@class='info-message disambiguation']");
        By editedLocation = By.XPath("//span[@data-id='910GILFORD']");
        By clearToLocationField = By.XPath("//a[text()='Clear To location']");
        By homeIcon = By.XPath("//span[text()='Home']");

        public void ClickHomeIcon()
        {
            Thread.Sleep(5000);
            context.driver.Navigate().Refresh();
            context.driver.FindElement(homeIcon).Click();
        }

        public void ClearToField()
        {
            context.driver.FindElement(clearToLocationField).Click();
        }
        public void EditToLocation()
        {
            context.driver.FindElement(editedLocation).Click();
        }

        public void ClickEditJourneyLink()
        {
            context.driver.FindElement(editJourneyLink).Click();
        }

        public void ClickUpdateJourneyButton()
        {
            context.driver.FindElement(updateJourneyBtn).Click();
        }

        public string CheckForConfirmationText()
        {
            return context.driver.FindElement(expectedConfirmationText).Text.Trim();
        }

        public string VerifyJourneyIsInvalid()
        {
            return context.driver.FindElement(invalidJourneyResult).Text.Trim();
        }
    }
}
