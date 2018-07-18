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
                IWebElement dropdown_Maat = driver.FindElement(By.CssSelector(@"z-grid-item.cat_filter-yI6Mr:nth-child(1)>div:nth-child(1)>div:nth-child(1)>div:nth-child(1)"));
                dropdown_Maat.Click();
                IList<IWebElement> dropdown_Maat_child = dropdown_Maat.FindElements(By.ClassName("cat_checkbox-w9QmM"));
                int Size = dropdown_Maat_child.Count;
                for (int i = 0; i < Size; i++)
                {
                    dropdown_Maat_child.ElementAt(i).Click();
                }

                //waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(@"z-grid-item.cat_filter-yI6Mr:nth-child(1)>div:nth-child(1)>div:nth-child(1)>div:nth-child(1)")));


                //IWebElement chkBx_Maat_parent = driver.FindElement(By.ClassName("cat_itemList-sgr85"));
                //IWebElement chkBx_Maat_child = chkBx_Maat_parent.FindElement(By.ClassName("content"));
                // IList <IWebElement> ListElmLi = driver.FindElements(By.TagName("li"));

                //Boolean bValue = false;

                //bValue = chkBx_Maat.ElementAt(0).Selected;

                // SelectElement sMaat = new SelectElement(dropdown_Maat_child) ;
                //waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(@"z-grid-item.cat_filter-yI6Mr:nth-child(1)>div:nth-child(1)>div:nth-child(1)>div:nth-child(1)")));
                //  sMaat.SelectByText("23");


                // driver.FindElement(By.CssSelector(@"a.z-navicat-header_gender:nth-child(2)>span:nth-child(1)")).Click();
                //Assert.AreEqual(@"https://www.zalando.nl/heren-home/", driver.Url);
                // waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(@"span.\30 _bb")));

                //  driver.FindElement(By.CssSelector(@"span.\30 _bb")).Click();
                //  Assert.AreEqual(@"https://www.zalando.nl/heren-home/#", driver.Url);



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
