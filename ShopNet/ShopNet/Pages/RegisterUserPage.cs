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



namespace ShopNet.POM
{
    public class RegisterUserPage : TestBase

    {
        public RegisterUserPage(IWebDriver _driver, WebDriverWait _waitf)
        {
            driver = _driver;
            waitf = _waitf;
        }

        public const string ButtonWomenSelector = "label[for='zds_radio_womens_0']";
        public const string ButtonTermsAndConditionsSelector = ".z-coast-reef_register_terms-and-conditions-checkbox label";
        public const string ErrorExistingUserSelector = "//span[.='Volgens ons heb je al een account. Probeer in te loggen. Wachtwoord vergeten? Vraag een nieuwe aan.'";

        [FindsBy(How = How.Name, Using = "register.firstname")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Name, Using = "register.lastname")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.Name, Using = "register.email")]
        public IWebElement RegisterEmail { get; set; }

        [FindsBy(How = How.Name, Using = "register.password")]
        public IWebElement RegisterPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = ButtonWomenSelector)]
        public IWebElement ButtonGender { get; set; }

        [FindsBy(How = How.CssSelector, Using = ButtonTermsAndConditionsSelector)]
        public IWebElement ButtonTermsAndConditions { get; set; }

        [FindsBy(How = How.Name, Using = "register.newsletter")]
        public IWebElement RegisterLetter { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[data-testid='register_button']")]
        public IWebElement ButtonRegister { get; set; }

        [FindsBy(How = How.Id, Using = "uc-btn-accept-banner")]
        public IWebElement BannerAccept { get; set; }

        [FindsBy(How = How.XPath, Using = ErrorExistingUserSelector)]
        public IWebElement ErrorExistingUser { get; set; }

        public void InsertRegisterValue(IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public string getErrorText()
        {
            return ErrorExistingUser.Text;

        }

        //To select element we need to scroll page and then perform an action
        public void SelectCheckBox(string bySelector)
        {
            var element = driver.FindElement(By.CssSelector(bySelector));
            ScrollToView(element);
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
            var parent = element.FindElement(By.XPath(".."));
            element.Click();
        }

        public void RegisterUser()
        {
            ButtonRegister.Click();
        }

        //helpers to perform scrolling : there are 3 different variants how we can scroll
        public void ScrollTo(int xPosition = 0, int yPosition = 0)
        {
            var js = String.Format("window.scrollTo({0}, {1})", xPosition, yPosition);
            ((IJavaScriptExecutor)driver).ExecuteScript(js);
        }

        public IWebElement ScrollToView(By selector)
        {
            var element = driver.FindElement(selector);
            ScrollToView(element);
            return element;
        }

        public void ScrollToView(IWebElement element)
        {
            if (element.Location.Y > 200)
            {
                ScrollTo(0, element.Location.Y - 100); // Make sure element is in the view but below the top navigation pane
            }

        }

    }
}
