using System;
using TechTalk.SpecFlow;
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
        public JourneyPlannerSteps(Homepage _homepage, Context _context, JourneyResultPage _journeyResultPage)
        {
            homepage = _homepage;
            context = _context;
            journeyResultPage = _journeyResultPage;
        }
        [Given(@"that TFL website is loaded")]
        public void GivenThatTFLWebsiteIsLoaded()
        {
            context.LaunchTFLApplication();
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

        [AfterScenario]
        public void CloseTFLApplication()
        {
            context.CloseTFLApplication();
        }
    }
}
