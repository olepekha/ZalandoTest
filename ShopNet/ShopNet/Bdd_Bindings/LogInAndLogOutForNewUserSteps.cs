using System;
using TechTalk.SpecFlow;

namespace ShopNet.Bdd_Features.Flows
{
    [Binding]
    public class LogInAndLogOutForNewUserSteps
    {
        [Given(@"I am on the site ""(.*)"" page")]
        public void GivenIAmOnTheSitePage(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I lick on ""(.*)"" button on the ""(.*)"" poup windows")]
        public void WhenILickOnButtonOnThePoupWindows(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I wait until register page is open")]
        public void WhenIWaitUntilRegisterPageIsOpen()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I enter ""(.*)"" into ""(.*)"" field on the ""(.*)"" page")]
        public void WhenIEnterIntoFieldOnThePage(string p0, string p1, string p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click on ""(.*)"" checkbox on the ""(.*)"" page")]
        public void WhenIClickOnCheckboxOnThePage(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click on ""(.*)"" check box")]
        public void WhenIClickOnCheckBox(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click on ""(.*)"" checkbox")]
        public void WhenIClickOnCheckbox(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click on ""(.*)"" button on ""(.*)"" page")]
        public void WhenIClickOnButtonOnPage(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click on ""(.*)"" link on the ""(.*)"" page")]
        public void WhenIClickOnLinkOnThePage(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click on ""(.*)"" link on the ""(.*)"" list")]
        public void WhenIClickOnLinkOnTheList(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I loged in to the ""(.*)"" page")]
        public void ThenILogedInToThePage(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I loged out to the ""(.*)"" page")]
        public void ThenILogedOutToThePage(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
