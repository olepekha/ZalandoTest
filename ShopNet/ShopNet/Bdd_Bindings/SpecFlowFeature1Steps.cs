using System;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium.Interactions;
using log4net;
using log4net.Repository.Hierarchy;
using NUnit.Framework.Internal;
using SpecFlow.Assist.Dynamic;
using TechTalk.SpecFlow.Assist;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;


namespace ShopNet.Bdd_Bindings
{
    [Binding]
    public class SpecFlowFeature1Steps

    {

        public IWebDriver driver;
        public WebDriverWait waitf;
        TimeSpan t = new TimeSpan(0, 0, 10);//for timer set

        [Given(@"I have entered '(.*)' into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(string p0)
        {
            Console.WriteLine("Number", p0);
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            Console.WriteLine("Adding the values");
        }
        
        [Then(@"the result should be '(.*)' on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(string p0)
        {
            Console.WriteLine("Result", p0);
        }
    }
}
