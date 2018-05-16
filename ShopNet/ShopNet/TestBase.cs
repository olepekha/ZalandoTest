using System;
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

namespace ShopNet
{
    public class TestBase
    {
       public IWebDriver driver;

       public WebDriverWait waitf;

        TimeSpan t = new TimeSpan(0, 0, 10);//for timer set


        [SetUp]
        public void Initialize() //start browser
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            waitf = new WebDriverWait(driver, t);

        }

        [TearDown]
        public void CloseBrowser() //
        {

            driver.Quit();
        }
    }


}
