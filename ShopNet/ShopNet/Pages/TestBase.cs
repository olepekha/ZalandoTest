using log4net.Config;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using log4net.Core;
using log4net;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;


namespace ShopNet
{
    public class TestBase
    {
       public IWebDriver driver;
       public WebDriverWait waitf;
       TimeSpan t = new TimeSpan(0, 0, 10);//for timer set
        public ILog logger ;
        protected ExtentReports extent;
        protected ExtentReports report;
        protected ExtentHtmlReporter htmlReporter;
        protected ExtentTest test;
        public TestBase()
        {
            //Log4Net configuration
             XmlConfigurator.Configure();
            //Create a logger.logger was in TesBase created and to the app.config added
            logger = log4net.LogManager.GetLogger(typeof(TestBase));
            // Create test report
            htmlReporter = new ExtentHtmlReporter(@"C:\Users\Metastorm\Documents\Visual Studio 2013\Projects\ShopNet\ShopNet\testreport.html");
            htmlReporter.Configuration().Theme = Theme.Dark;
            htmlReporter.Configuration().DocumentTitle = "Test Report | Olga Lepekha";
            htmlReporter.Configuration().ReportName = "Test Report | Olga Lepekha";

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);


        }

        public void Initialize(String BrowserName) 
        {
            logger.Info("Init method has been called");
            if (BrowserName.Equals("firefox"))
            {
                driver = new FirefoxDriver();
            }
            else 
                driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Manage().Window.Maximize();
            waitf = new WebDriverWait(driver, t);

                       
        }
     

        [TearDown]
        public void CloseBrowser() 
        {

            driver.Quit();
        }


        public static IEnumerable<String> BrowsersToRunWith() 

        { 
        String[] browsers = {"chrome", "firefox"};

        foreach (String b in browsers)
        {
            yield return b;
        }
        
        }
    }


    
}
