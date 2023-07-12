using System;
using System.IO;
using TechTalk.SpecFlow;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using TFLSTAExercises.Pages;
using TFLSTAExercises.Hooks;
using NUnit.Framework;
using System.Threading;

namespace TFLSTAExercises.StepDefinition
{
    [Binding]
    public class JourneyPlannerSteps
    {
        Homepage homepage;
        Context context;
        JourneyResultPage journeyResultPage;
        ScenarioContext scenarioContext;
        static ExtentTest feature;
        static ExtentTest scenario;
        static ExtentReports report;
        public JourneyPlannerSteps(Homepage _homepage, Context _context, 
               JourneyResultPage _journeyResultPage, ScenarioContext _scenarioContext)
        {
            homepage = _homepage;
            context = _context;
            journeyResultPage = _journeyResultPage;
            scenarioContext = _scenarioContext;
        }
        [Given(@"that TFL website is loaded")]
        public void GivenThatTFLWebsiteIsLoaded()
        {
            context.LaunchTFLApplication();
            scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [When(@"a user clicks on the Accept all cookies button")]
        public void WhenAUserClicksOnTheAcceptAllCookiesButton()
        {
            homepage.AcceptAllCookies();
        }

        [When(@"a user fills-in the From text field with '(.*)'")]
        public void WhenAUserFills_InTheFromTextFieldWith(string from)
        {
            homepage.FillInFromTextField(from);
        }

        [When(@"a user clicks on '(.*)' from the list suggested for From field")]
        public void WhenAUserClicksOnFromTheListSuggestedForFromField(string fromLocation)
        {
            homepage.SelectFromLocationDropdown();
        }


        [When(@"a user fills-in the To text field with '(.*)'")]
        public void WhenAUserFills_InTheToTextFieldWith(string to)
        {
            homepage.FillInToField(to);
        }

        [When(@"a user clicks on '(.*)' from the list suggested for To field")]
        public void WhenAUserClicksOnFromTheListSuggestedForToField(string toLocation)
        {
            homepage.SelectToLocationDropdown();
        }

        [When(@"a user clicks on plan my journey button")]
        public void WhenAUserClicksOnPlanMyJourneyButton()
        {
            homepage.ClickPlanMyJourneyButton();
        }

        [When(@"a user clicks on Change Time link")]
        public void WhenAUserClicksOnChangeTimeLink()
        {
            homepage.ClickChangeTimeLink();
        }

        [When(@"a user clicks on the arriving option button")]
        public void WhenAUserClicksOnTheArrivingOptionButton()
        {
            homepage.ClickArrivingButton();
        }

        [When(@"a user selects '(.*)' from the date dropdown")]
        public void WhenAUserSelectsFromTheDateDropdown(string date)
        {
            homepage.SelectDateFromDropdown(date);
        }

        [When(@"a user selects selects '(.*)' from the time dropdown")]
        public void WhenAUserSelectsSelectsFromTheTimeDropdown(string time)
        {
            homepage.SelectTimeFromDropdown(time);
        }

        [When(@"a user clicks the Edit journey link")]
        public void WhenAUserClicksTheEditJourneyLink()
        {
            journeyResultPage.ClickEditJourneyLink();
        }

        [When(@"a user clicks the Clear-field icon")]
        public void WhenAUserClicksTheClear_FieldIcon()
        {
            journeyResultPage.ClearToField();
        }


        [When(@"a user clicks on '(.*)' from the list of suggested for edit")]
        public void WhenAUserClicksOnFromTheListOfSuggestedForEdit(string editedToLocation)
        {
            journeyResultPage.EditToLocation();
        }


        [When(@"a user clicks on Update Journey button")]
        public void WhenAUserClicksOnUpdateJourneyButton()
        {
            journeyResultPage.ClickUpdateJourneyButton();
        }

        [When(@"a user clicks on the Recents link")]
        public void WhenAUserClicksOnTheRecentsLink()
        {
            homepage.ClickRecentLink();
        }

        [When(@"a user clicks the Home icon")]
        public void WhenAUserClicksTheHomeIcon()
        {
            journeyResultPage.ClickHomeIcon();
        }


        [Then(@"a journey result page showing '(.*)' must be loaded")]
        public void ThenAJourneyResultPageShowingMustBeLoaded(string expectedResult)
        {
            string actualResult = journeyResultPage.CheckForConfirmationText();
            Assert.IsTrue(actualResult.Contains(expectedResult));
        }

        [Then(@"the journey result page must load '(.*)' input")]
        public void ThenTheJourneyResultPageMustLoadInput(string expectedInvalidJourneyMessage)
        {
            string actualInvalidJourneyMessage = journeyResultPage.VerifyJourneyIsInvalid();
            Assert.IsTrue(actualInvalidJourneyMessage.Contains(expectedInvalidJourneyMessage));
        }

        [Then(@"a user must get an error message stating '(.*)'")]
        public void ThenAUserMustGetAnErrorMessageStating(string expectedErrorMessage)
        {
            string actualErrorMessage = homepage.VerifyFromErrorMessage();
            Assert.IsTrue(actualErrorMessage.Contains(expectedErrorMessage));
        }

        [Then(@"a user must see the '(.*)' option")]
        public void ThenAUserMustSeeTheArrivingOption(string expectedDisplayText)
        {
            string actualDisplayText = homepage.VerifyVisibilityOfArrivingButton();
            Assert.IsTrue(actualDisplayText.Contains(expectedDisplayText));
        }

        [Then(@"a list of recent journeys must be displayed with '(.*)' link below the list")]
        public void ThenAListOfRecentJourneysMustBeDisplayedWithLinkBelowTheList(string expectedConfirmationLink)
        {
            string actualConfirmationLink = homepage.ConfirmRecentLocationList();
            Assert.IsTrue(actualConfirmationLink.Contains(expectedConfirmationLink));
        }

        [BeforeTestRun]
        public static void ReportGenerator()
        {
            var testResultReport = new ExtentV3HtmlReporter(AppDomain.CurrentDomain.BaseDirectory + @"\TestResult.html");
            testResultReport.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            report = new ExtentReports();
            report.AttachReporter(testResultReport);
        }

        [AfterTestRun]
        public static void ReportCleaner()
        {
            report.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            feature = report.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterStep]
        public void StepsInTheReport()
        {
            var typeOfStep = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (scenarioContext.TestError == null)
            {
                if (typeOfStep.Equals("Given"))
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (typeOfStep.Equals("When"))
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (typeOfStep.Equals("Then"))
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                }
            }
            
            if (scenarioContext.TestError != null)
            {
                if (typeOfStep.Equals("Given"))
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                }
                else if (typeOfStep.Equals("When"))
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                }
                else if (typeOfStep.Equals("Then"))
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                }
            }
        }

        [AfterScenario]
        public void CloseTFLApplication()
        {
            try
            {
                if (scenarioContext.TestError != null)
                {
                    string scenarioName = scenarioContext.ScenarioInfo.Title;
                    string directory = AppDomain.CurrentDomain.BaseDirectory + @"\ReportScreenshots\";
                    context.TakeScreenshotAtThePointOfTestFailure(directory, scenarioName);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                context.CloseTFLApplication();
            }
        }
    }
}
