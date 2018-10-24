using System;
using TechTalk.SpecFlow;

namespace ShopNet
{
    [Binding]
    public class LogInAndLogOutForNewUserSteps
    {
        [Given(@"I am on the site home page ""(.*)""")]
        public void GivenIAmOnTheSiteHomePage(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click on ""(.*)"" link on the home page")]
        public void WhenIClickOnLinkOnTheHomePage(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
