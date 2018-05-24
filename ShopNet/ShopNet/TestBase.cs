using log4net.Config;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using log4net.Core;


namespace ShopNet
{
    public class TestBase
    {
       public IWebDriver driver;

       public WebDriverWait waitf;

        TimeSpan t = new TimeSpan(0, 0, 10);//for timer set


        //Хочу сконфигурировать Log4Net
        // XmlConfigurator.Configure();
        //Creating a logger
        //ILogs logger = LoggerManager.GetLogger("TestLogs");
        
        public void Initialize(String BrowserName) //lunch browser
        {
            if (BrowserName.Equals("firefox"))
                driver = new FirefoxDriver();
            else 
                driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            waitf = new WebDriverWait(driver, t);

                       
        }
        
   

        [TearDown]
        public void CloseBrowser() //
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
