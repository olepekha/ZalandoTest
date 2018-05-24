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

namespace ShopNet
{
    public class TestBase
    {
       public IWebDriver driver;

       public WebDriverWait waitf;

        TimeSpan t = new TimeSpan(0, 0, 10);//for timer set

<<<<<<< HEAD
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        //Хочу сконфигурировать Log4Net
        //XmlConfigurator.Configure();
        //Creating a logger
        //ILogs logger = LoggerManager.GetLogger("TestLogs");

=======
        ILog logger ;
        public TestBase()
        {
            //Хочу сконфигурировать Log4Net
             XmlConfigurator.Configure();
            //Creating a logger
            logger = log4net.LogManager.GetLogger(typeof(TestBase));
        }
        
>>>>>>> 5985ab4059ab93b832ce04c7245d6224ade57bb0
        public void Initialize(String BrowserName) //lunch browser
        {
            logger.Info("Init method has been called");
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
