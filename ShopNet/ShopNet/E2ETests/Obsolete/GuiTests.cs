﻿using System;
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
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace ShopNet
{
    [TestFixture]

    class GuiTests : TestBase

    {
        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void HomePage_LinksValidation(String BrowserName) //user should be created
        {

            try
            {
                Initialize(BrowserName);
                //Create Test report using ExtentReports
                test = extent.CreateTest("HomePage_LinksValidation");
                extent.Flush();
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
                driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
                //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
                 driver.FindElement(By.CssSelector(@".z-navicat-header_gender.z-navicat-header_gender-active")).Click();
                Assert.AreEqual(@"https://www.zalando.nl/dames-home/", driver.Url);

                //find "Inspiratie" element (span.\30 _bb)
                //waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(@"span.\30 _bb")));

                driver.FindElement(By.CssSelector(@"span.\31 _bb")).Click();
                Assert.AreEqual(@"https://www.zalando.nl/dames-home/#", driver.Url);


                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("cat_filterHead-3-7Lz")));

                //Verify drop box selection for: field Maat on Dames kleding page
                var ulElement = driver.FindElement(By.ClassName("cat_filterHead-3-7Lz"));
                ulElement.Click();
                
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("cat_itemList-sgr85")));
                var listElement = driver.FindElement(By.ClassName("cat_itemList-sgr85"));
                var liElements = listElement.FindElements(By.ClassName("cat_checkboxOption-w9fJZ"));
                int Size = liElements.Count;
                for (int i = 0; i < Size; i++)
                {
                    liElements.ElementAt(i).Click();
                }
                var firstLI = liElements.ToList().FirstOrDefault();
                //liElements.ToList().ForEach(q=>q.Click());//.FirstOrDefault();

                if (firstLI != null)
                    firstLI.Click();
                var a = driver.FindElement(By.ClassName("cat_saveButton-1KxIT"));
                a.Click();
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(@"__maat-23/"));
                Assert.AreEqual(@"https://www.zalando.nl/dameskleding/__maat-23/", driver.Url);

                //Verify home page links are clickable
                driver.FindElement(By.CssSelector(@"a.z-navicat-header_gender:nth-child(2)>span:nth-child(1)")).Click();
                Assert.AreEqual(@"https://www.zalando.nl/heren-home/", driver.Url);
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(@"span.\30 _bb")));

                driver.FindElement(By.CssSelector(@"span.\30 _bb")).Click();
                Assert.AreEqual(@"https://www.zalando.nl/heren-home/#", driver.Url);

                driver.FindElement(By.CssSelector(@"a.z-navicat-header_gender:nth-child(3) > span:nth-child(1)")).Click();
                Assert.AreEqual(@"https://www.zalando.nl/kinderen-home/", driver.Url);


            }
            catch (Exception ex)
            {
                test.Fail(ex.StackTrace + ex.Message + ex.Source);
                //set a logger error format
                logger.ErrorFormat($"Exception on 'z-navicat-header_gender': Message {ex.Message}; StackTrace:{ex.StackTrace}");
                throw;
            }
        }
        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void HomePage_LogoIsPresent(String BrowserName) {

            try
            {
                Initialize(BrowserName);
                //Create Test report using ExtentReports
                test = extent.CreateTest("HomePage_LinksValidation");
                extent.Flush();
                driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
                bool PageLogo = driver.FindElement(By.ClassName("z-navicat-header_svgLogo")).Displayed;
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                //driver.PageSource.Contains("Zalando");
                //Verify Logo on the page
                Assert.IsTrue(PageLogo);

            }
            catch (Exception ex)
            {
                test.Fail(ex.StackTrace + ex.Message + ex.Source);
                //set a logger error format
                logger.ErrorFormat($"Exception : Message {ex.Message}; StackTrace:{ex.StackTrace}");
                throw;
            }

        }
        }
    }

