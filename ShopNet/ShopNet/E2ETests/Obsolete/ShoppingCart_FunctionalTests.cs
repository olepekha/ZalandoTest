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
using log4net;
using log4net.Repository.Hierarchy;
using NUnit.Framework.Internal;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace ShopNet
{
    class ShoppingCart_FunctionalTests :TestBase
    {
        [Test]
        [Parallelizable]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void AddOneItemToTheCart(String BrowserName)
        {
            try
            {
                //Create Test report using ExtentReports
                test = extent.CreateTest("AddOneItemToTheCart");
                extent.Flush();
                Initialize(BrowserName);
                driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
                driver.FindElement(By.CssSelector(@"span.\35 _bb")).Click();
                Assert.AreEqual(@"https://www.zalando.nl/tassen-accessoires/", driver.Url);
                Thread.Sleep(10000);
                var listOfGridElements = driver.FindElements(By.ClassName("cat_articles"));
                var firstLI = listOfGridElements.ToList().FirstOrDefault();
                if (firstLI != null)
                {
                    firstLI.Click();
                }
                else
                {
                    Assert.Fail("Grid element not found.");
                    //ElementAt(1).Click();
                }

                // add  this element to cart - BUY button
                driver.FindElement(By.Id("z-pdp-topSection-addToCartButton")).Click();
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(@".z-navicat-header_navToolItem.z-navicat-header_navToolItem-bag"))); //wait page is reload and cart link is present 
                 //click on cart element                                                                                                                                                               //go to the cart
                driver.FindElement(By.CssSelector(@".z-navicat-header_navToolItem.z-navicat-header_navToolItem-bag")).Click();
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://www.zalando.nl/cart/"));
                //cart contains 1 item
                Assert.AreEqual(driver.FindElement(By.ClassName("z-coast-base__tile-title")).Text, "Winkelwagen (1 items)");

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
        [Parallelizable]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void AddTheSameItemToTheCart(String BrowserName)
        {
            Initialize(BrowserName);
            driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
            var SearchEl = driver.FindElement(By.ClassName("z-navicat-header_searchInput"));
            SearchEl.SendKeys("furla tassen");
            // click on firstelement
            driver.FindElement(By.CssSelector(@".z-icon.z-icon-search-semi-bold.z-icon-small.z-icon-black")).Click();
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://www.zalando.nl/dames/?q=furla+tassen"));
            //find titel of element and get text
            var firstItemTitleElement = driver.FindElement(By.CssSelector(@".cat_brandName-2XZRz.cat_ellipsis-MujnT"));
            String firstItemTitle = firstItemTitleElement.Text;
            //click on element
            firstItemTitleElement.Click();
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("h-m-bottom-m")));
            //finde this element by titel after page is reload
            var titelElement = driver.FindElement(By.ClassName("h-m-bottom-m")).Text;
            // compare two titels of one element and verify that titel is the same after page reload
            Assert.AreEqual(firstItemTitle, titelElement);
            Thread.Sleep(10000);
            // add  this element to cart - BUY button
            driver.FindElement(By.Id("z-pdp-topSection-addToCartButton")).Click();
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("z-pdp-topSection-addToCartButton")));
            Thread.Sleep(10000);
            //add second time the same element
            driver.FindElement(By.Id("z-pdp-topSection-addToCartButton")).Click();
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(@".z-navicat-header_navToolItem.z-navicat-header_navToolItem-bag"))); //wait page is reload and cart link is present 
            Thread.Sleep(10000);
            //go to the cart
            driver.FindElement(By.CssSelector(@".z-navicat-header_navToolItem.z-navicat-header_navToolItem-bag")).Click();
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://www.zalando.nl/cart/"));
            //cart contains 2 item
            var a = driver.FindElement(By.CssSelector(@".z-2-text.z-2-text-title-4.z-2-text-black")).Text;
            Assert.AreEqual("Winkelwagen (2 items)",a); //Warenkorb (2 Artikel)"

        }

        [Test]
        [Parallelizable]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void AddDifferenItemToTheCart(String BrowserName)
        {
            Initialize(BrowserName);
            driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
            Thread.Sleep(10000);
            //search for element
            var SearchEl = driver.FindElement(By.ClassName("z-navicat-header_searchInput"));
            SearchEl.SendKeys("furla tassen");
            // click on firstelement
            driver.FindElement(By.CssSelector(@".z-icon.z-icon-search-semi-bold.z-icon-small.z-icon-black")).Click();
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://www.zalando.nl/dames/?q=furla+tassen"));
            //find titel of element and get text
            var firstItemTitleElement = driver.FindElement(By.CssSelector(@".cat_brandName-2XZRz.cat_ellipsis-MujnT"));
            String firstItemTitle = firstItemTitleElement.Text;
            //click on element
            firstItemTitleElement.Click();
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("h-m-bottom-m")));
            //finde this element by titel after page is reload
            var titelElement= driver.FindElement(By.ClassName("h-m-bottom-m")).Text;
            // compare two titels of one element and verify that titel is the same after page reload
            Assert.AreEqual(firstItemTitle, titelElement); 
            Thread.Sleep(10000);
            // add  this element to cart - BUY button
            driver.FindElement(By.Id("z-pdp-topSection-addToCartButton")).Click(); 
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(@".z-navicat-header_navToolItem.z-navicat-header_navToolItem-bag"))); //wait page is reload and cart link is present 
            //go to the cart
            driver.FindElement(By.CssSelector(@".z-navicat-header_navToolItem.z-navicat-header_navToolItem-bag")).Click();
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://www.zalando.nl/cart/"));
            //cart contains 1 item
            Assert.AreEqual(driver.FindElement(By.ClassName("z-coast-base__tile-title")).Text, "Winkelwagen (1 items)");

            // second item
            driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
            driver.FindElement(By.CssSelector(@"span.\35 _bb")).Click();
            Assert.AreEqual(@"https://www.zalando.nl/tassen-accessoires/", driver.Url);
            Thread.Sleep(10000);
            var listOfGridElements  =driver.FindElements(By.ClassName("cat_articles"));
            var firstLI = listOfGridElements.ToList().FirstOrDefault();
            if (firstLI != null)
            {
                firstLI.Click();
            }
            else
            {
                Assert.Fail("Grid element not found.");
                //ElementAt(1).Click();
            }

            driver.FindElement(By.Id("z-pdp-topSection-addToCartButton")).Click();
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(@".z-navicat-header_navToolItem.z-navicat-header_navToolItem-bag"))); //wait page is reload and cart link is present 
            //go to the cart
            driver.FindElement(By.CssSelector(@".z-navicat-header_navToolItem.z-navicat-header_navToolItem-bag")).Click();
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://www.zalando.nl/cart/"));
            //cart contains 2 items
            Assert.AreEqual(driver.FindElement(By.ClassName("z-coast-base__tile-title")).Text, "Warenkorb (2 Artikel)");

        }

        [Test]
        [Parallelizable]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void RemoveOneItemFromTheCart(String BrowserName)
        {
            Initialize(BrowserName);
            driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
            var SearchEl = driver.FindElement(By.ClassName("z-navicat-header_searchInput"));
            SearchEl.SendKeys("furla tassen");
            // click on firstelement
            driver.FindElement(By.CssSelector(@".z-icon.z-icon-search-semi-bold.z-icon-small.z-icon-black")).Click();
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://www.zalando.nl/dames/?q=furla+tassen"));
            //find titel of element and get text
            var firstItemTitleElement = driver.FindElement(By.CssSelector(@".cat_brandName-2XZRz.cat_ellipsis-MujnT"));
            String firstItemTitle = firstItemTitleElement.Text;
            //click on element
            firstItemTitleElement.Click();
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("h-m-bottom-m")));
            //finde this element by titel after page is reload
            var titelElement = driver.FindElement(By.ClassName("h-m-bottom-m")).Text;
            // compare two titels of one element and verify that titel is the same after page reload
            Assert.AreEqual(firstItemTitle, titelElement);
            Thread.Sleep(10000);
            // add  this element to cart - BUY button
            driver.FindElement(By.Id("z-pdp-topSection-addToCartButton")).Click();
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(@".z-navicat-header_navToolItem.z-navicat-header_navToolItem-bag"))); //wait page is reload and cart link is present 
            //go to the cart
            driver.FindElement(By.CssSelector(@".z-navicat-header_navToolItem.z-navicat-header_navToolItem-bag")).Click();
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://www.zalando.nl/cart/"));
            //cart contains 1 item
            //Assert.AreEqual(driver.FindElement(By.ClassName("z-coast-base__tile-title")).Text, "Winkelwagen (1 items)");

            // second item
            driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
            driver.FindElement(By.CssSelector(@"span.\35 _bb")).Click();
            Assert.AreEqual(@"https://www.zalando.nl/tassen-accessoires/", driver.Url);
            Thread.Sleep(10000);
            var listOfGridElements = driver.FindElements(By.ClassName("cat_articles"));
            var firstLI = listOfGridElements.ToList().FirstOrDefault();
            if (firstLI != null)
            {
                firstLI.Click();
            }
            else
            {
                Assert.Fail("Grid element not found.");
                //ElementAt(1).Click();
            }

            driver.FindElement(By.Id("z-pdp-topSection-addToCartButton")).Click();
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(@".z-navicat-header_navToolItem.z-navicat-header_navToolItem-bag"))); //wait page is reload and cart link is present 
            //go to the cart
            driver.FindElement(By.CssSelector(@".z-navicat-header_navToolItem.z-navicat-header_navToolItem-bag")).Click();
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://www.zalando.nl/cart/"));
            //cart contains 2 items
            //Assert.AreEqual(driver.FindElement(By.ClassName("z-coast-base__tile-title")).Text, "Warenkorb (2 Artikel)");
            // remove one item
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(".z-2-text.z-2-text-detail-text-regular.z-2-text-mediumgray")));
            driver.FindElement(By.CssSelector(@".z-2-text.z-2-text-detail-text-regular.z-2-text-mediumgray")).Click();
            Thread.Sleep(10000);
            Assert.AreEqual(driver.FindElement(By.ClassName("z-coast-base__tile-title")).Text, "Winkelwagen (1 items)"); //Winkelwagen (1 items)"


        }

        [Test]
        [Parallelizable]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void RemoveAllItemsFromTheCart(String BrowserName)
        {
            Initialize(BrowserName);
            driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
            var SearchEl = driver.FindElement(By.ClassName("z-navicat-header_searchInput"));
            SearchEl.SendKeys("furla tassen");
            // click on firstelement
            driver.FindElement(By.CssSelector(@".z-icon.z-icon-search-semi-bold.z-icon-small.z-icon-black")).Click();
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://www.zalando.nl/dames/?q=furla+tassen"));
            //find titel of element and get text
            var firstItemTitleElement = driver.FindElement(By.CssSelector(@".cat_brandName-2XZRz.cat_ellipsis-MujnT"));
            String firstItemTitle = firstItemTitleElement.Text;
            //click on element
            firstItemTitleElement.Click();
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("h-m-bottom-m")));
            //finde this element by titel after page is reload
            var titelElement = driver.FindElement(By.ClassName("h-m-bottom-m")).Text;
            // compare two titels of one element and verify that titel is the same after page reload
            Assert.AreEqual(firstItemTitle, titelElement);
            Thread.Sleep(10000);
            // add  this element to cart - BUY button
            driver.FindElement(By.Id("z-pdp-topSection-addToCartButton")).Click();
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(@".z-navicat-header_navToolItem.z-navicat-header_navToolItem-bag"))); //wait page is reload and cart link is present 
            //go to the cart
            driver.FindElement(By.CssSelector(@".z-navicat-header_navToolItem.z-navicat-header_navToolItem-bag")).Click();
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://www.zalando.nl/cart/"));
            //cart contains 1 item
            Assert.AreEqual(driver.FindElement(By.ClassName("z-coast-base__tile-title")).Text, "Winkelwagen (1 items)");
            //remove item
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(".z-2-text.z-2-text-detail-text-regular.z-2-text-mediumgray")));
            driver.FindElement(By.CssSelector(@".z-2-text.z-2-text-detail-text-regular.z-2-text-mediumgray")).Click();
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(@".z-2-text.z-2-text-default-bold.z-2-text-black")));
            var remElement = driver.FindElement(By.CssSelector(@".z-2-text.z-2-text-default-bold.z-2-text-black")).Text;
            Assert.AreEqual(remElement, "Je hebt geen artikelen in je winkelwagen."); //Je hebt geen artikelen in je winkelwagen."


        }

        //test for developing: Increase the quantity of the item from the cart ,Click on an item in the cart ,Coupons 
    }

}
