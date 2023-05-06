using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TFLSTAExercises.Hooks;

namespace TFLSTAExercises.Pages
{
    public class Homepage
    {
        Context context;
        public Homepage(Context _context)
        {
            context = _context;
        }

        By fromTextField = By.Id("InputFrom");
        By toTextField = By.Id("InputTo");
        By planMyJourneyBtn = By.Id("plan-journey-button");
        By recentLink = By.XPath("//li[@id='jp-recent-tab-home']/a");
        By changeTimeLink = By.XPath("//a[@class='change-departure-time']");
        By arrivingBtn = By.XPath("//label[text()='Arriving']");
        By dateDropdown = By.Id("Date");
        By timedropdown = By.Id("Time");
        By acceptCookies = By.XPath("//strong[text()='Accept all cookies']");
        By fromError = By.Id("InputFrom-error");
        By location1Suggestions = By.XPath("//span[@data-id='910GBNSLY']");
        By location2Suggestions = By.XPath("//span[@data-id='910GBOLTON']");
        By clearRecent = By.XPath("//div[@id='jp-recent-content-home-']/div[@class]/div[@class='turn-off-recents']/a");

        public void SelectFromLocationDropdown()
        {
            context.driver.FindElement(location1Suggestions).Click();
        }

        public void SelectToLocationDropdown()
        {
            context.driver.FindElement(location2Suggestions).Click();
        }
        public void AcceptAllCookies()
        {
            context.driver.FindElement(acceptCookies).Click();
        }

        public void FillInFromTextField(string from)
        {
            context.driver.FindElement(fromTextField).Clear();
            context.driver.FindElement(fromTextField).SendKeys(from);
        }

        public void FillInToField(string to)
        {
            context.driver.FindElement(toTextField).Clear();
            context.driver.FindElement(toTextField).SendKeys(to);
        }

        public void ClickRecentLink()
        {
            context.driver.FindElement(recentLink).Click();
        }

        public void ClickChangeTimeLink()
        {
            context.driver.FindElement(changeTimeLink).Click();
        }

        public void ClickArrivingButton()
        {
            context.driver.FindElement(arrivingBtn).Click();
        }

        public void SelectTimeFromDropdown(string time)
        {
            IWebElement selectTime = context.driver.FindElement(timedropdown);
            selectTime.Click();
            SelectElement select = new SelectElement(selectTime);
            select.SelectByText(time);
        }

        public void SelectDateFromDropdown(string date)
        {
            IWebElement selectDate = context.driver.FindElement(dateDropdown);
            selectDate.Click();
            SelectElement select = new SelectElement(selectDate);
            select.SelectByText(date);
        }

        public JourneyResultPage ClickPlanMyJourneyButton()
        {
            context.driver.FindElement(planMyJourneyBtn).Click();
            return new JourneyResultPage(context);
        }

        public string VerifyVisibilityOfArrivingButton()
        {
            return context.driver.FindElement(arrivingBtn).Text.Trim();
        }

        public string ConfirmRecentLocationList()
        {
            return context.driver.FindElement(clearRecent).Text.Trim();
        }
        public string VerifyFromErrorMessage()
        {
            return context.driver.FindElement(fromError).Text.Trim();
        }
    }
}
