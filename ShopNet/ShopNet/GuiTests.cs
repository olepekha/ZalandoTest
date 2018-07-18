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

namespace ShopNet
{
    [TestFixture]

    class GuiTests : TestBase

    {
        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void HomePage_LinksValidation(String BrowserName) //user should be created
        {
            Initialize(BrowserName);
            try
            {
                driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);

                driver.FindElement(By.CssSelector(@".z-navicat-header_gender.z-navicat-header_gender-active")).Click(); 
                Assert.AreEqual(@"https://www.zalando.nl/dames-home/", driver.Url);

                //find "Inspiratie" element span.\30 _bb
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(@"span.\30 _bb")));

                driver.FindElement(By.CssSelector(@"span.\30 _bb")).Click();
                Assert.AreEqual(@"https://www.zalando.nl/dames-home/#", driver.Url);

                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(@"span.\31 _bb")));

                driver.FindElement(By.CssSelector(@"span.\31 _bb")).Click();
                Assert.AreEqual(@"https://www.zalando.nl/dameskleding/", driver.Url);


                //find "Maat" element
                driver.FindElement(By.CssSelector(@"z-grid-item.cat_filter-yI6Mr:nth-child(1)>div:nth-child(1)>div:nth-child(1)>div:nth-child(1)")).Click();

               IList<IWebElement> chkBx_Maat = driver.FindElements(By.ClassName("cat_checkbox-w9QmM"));
                Boolean bValue = false;

                bValue = chkBx_Maat.ElementAt(0).Selected;





                driver.FindElement(By.CssSelector(@"a.z-navicat-header_gender:nth-child(2)>span:nth-child(1)")).Click();
                Assert.AreEqual(@"https://www.zalando.nl/heren-home/", driver.Url);
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(@"span.\30 _bb")));

                driver.FindElement(By.CssSelector(@"span.\30 _bb")).Click();
                Assert.AreEqual(@"https://www.zalando.nl/heren-home/#", driver.Url);

               

                //driver.FindElement(By.CssSelector(@"a.z-navicat-header_gender:nth-child(3) > span:nth-child(1)")).Click();
                // Assert.AreEqual(@"https://www.zalando.nl/kinderen-home/", driver.Url);


            }
            catch (Exception ex)
            {
                logger.ErrorFormat($"Exception on 'z-navicat-header_gender': Message {ex.Message}; StackTrace:{ex.StackTrace}");

                throw;
            }
        }
    }
}
