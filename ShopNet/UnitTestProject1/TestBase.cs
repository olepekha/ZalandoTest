﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
//using NUnit.Framework;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium.Interactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShopNet
{
    public class TestBase
    {
       public IWebDriver driver;

       public WebDriverWait waitf;

        TimeSpan t = new TimeSpan(0, 0, 10);//for timer set


        
        public void Initialize(String BrowserName) //lunch browser
        {
            if (BrowserName.Equals("firefox"))
                driver = new FirefoxDriver();
            else 
                driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            waitf = new WebDriverWait(driver, t);

                       
        }

        [TestCleanup]
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