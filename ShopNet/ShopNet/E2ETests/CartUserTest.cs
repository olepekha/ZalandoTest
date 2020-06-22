using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium.Interactions;
using NUnit.Framework.Internal;
using ShopNet.Pages;

namespace ShopNet.E2ETests
{
    class CartUserTest:TestBase
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
                CartUserPage page = new CartUserPage(driver, waitf);
                PageFactory.InitElements(driver, page);
                driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
                page.UserClick(page.Accessoires);
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
                }

                // add  this element to the cart 
                page.UserClick(page.AddToCart);
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(@".z-navicat-header_navToolItem.z-navicat-header_navToolItem-bag"))); //wait page is reload and cart link is present 
                //click on cart element                                                                                                                                                              
                page.UserClick(page.CartElement);
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://www.zalando.nl/cart/"));
                //cart contains 1 item
                Assert.AreEqual(page.GetText(page.CartTitle), "Winkelwagen (1 items)");

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
            CartUserPage page = new CartUserPage(driver, waitf);
            PageFactory.InitElements(driver, page);
            driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
            //input search parameter
            page.SendText(page.SearchInput, "furla tassen");
            // click on firstelement
            page.UserClick(page.FoundBySearchItem);
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://www.zalando.nl/dames/?q=furla+tassen"));
            //find titel of element and get text
            var firstItemTitleElement = page.CartBrandName;
            String firstItemTitle = firstItemTitleElement.Text;
            //click on element
            firstItemTitleElement.Click();
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("h-m-bottom-m")));
            //finde this element by titel after page is reload
            var titelElement = page.GetText(page.ElementTitle);
            // compare two titels of one element and verify that titel is the same after page reload
            Assert.AreEqual(firstItemTitle, titelElement);
            // add  this element to cart - BUY button
            page.UserClick(page.AddToCart);
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("z-pdp-topSection-addToCartButton")));
            //add second time the same element
            page.UserClick(page.AddToCart);
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(@".z-navicat-header_navToolItem.z-navicat-header_navToolItem-bag"))); //wait page is reload and cart link is present 
            Thread.Sleep(10000);
            //go to the cart
            page.UserClick(page.CartElement);
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://www.zalando.nl/cart/"));
            //cart contains 2 item
             Assert.AreEqual("Winkelwagen (2 items)", page.GetText(page.CartCount)); //Warenkorb (2 Artikel)"

        }

        [Test]
        [Parallelizable]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void RemoveOneItem(String BrowserName)
        {
            Initialize(BrowserName);
            CartUserPage page = new CartUserPage(driver, waitf);
            PageFactory.InitElements(driver, page);
            driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
            //input search parameter
            page.SendText(page.SearchInput, "furla tassen");
            // click on firstelement
            page.UserClick(page.FoundBySearchItem);
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://www.zalando.nl/dames/?q=furla+tassen"));
            //find titel of element and get text
            var firstItemTitleElement = page.CartBrandName;
            String firstItemTitle = firstItemTitleElement.Text;
            //click on element
            firstItemTitleElement.Click();
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("h-m-bottom-m")));
            // add  this element to cart - BUY button
            page.UserClick(page.AddToCart);
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("z-pdp-topSection-addToCartButton")));
            //add second time the same element
            page.UserClick(page.AddToCart);
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(@".z-navicat-header_navToolItem.z-navicat-header_navToolItem-bag"))); //wait page is reload and cart link is present 
            //go to the cart
            page.UserClick(page.CartElement);
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://www.zalando.nl/cart/"));
            //remove element
            page.UserClick(page.DeleteItem);
            Assert.AreEqual("Winkelwagen (1 items)", page.GetText(page.CartCount)); //Winkelwagen (1 items)"

        }

    }

}
