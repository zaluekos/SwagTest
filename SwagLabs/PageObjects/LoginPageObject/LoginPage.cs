using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using NLog;

namespace SwagLabs.PageObjects.LoginPageObject
{
    public class LoginPage : ILoginPage
    {
        private readonly IWebDriver _driver;
        private const string _url = "https://www.saucedemo.com/";

        private readonly WebDriverWait _waiter;
        public LoginPageMap Map { get; }
        public LoginPageValidator Validator { get; }

        public LoginPage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _waiter = new(_driver, TimeSpan.FromSeconds(5));
            Map = new(_driver);
            Validator = new(_driver);
        }
        public void Navigate()
        {
            _driver.Navigate().GoToUrl(_url);

        }
        public void WhenEnteredUsernameIs(string username)
        {
            if (_waiter.Until(c => Map.UsernameField.Enabled))
            {
                Map.UsernameField.SendKeys(username);

            }
        }
        public void WhenEnteredPasswordIs(string password)
        {
            if (_waiter.Until(c => Map.PasswordField.Enabled))
            {
                Map.PasswordField.SendKeys(password);
            }
        }
        public void WhenElementCleared(IWebElement element)
        {
            ArgumentNullException.ThrowIfNull(element);

            if (_waiter.Until(c => element.Enabled))
            {
                element.Click();
                element.SendKeys(Keys.Control + "a");
                element.SendKeys(Keys.Delete);
            }
        }

        public void WhenLoginButtonPressed()
        {
            if (_waiter.Until(cond => Map.LoginButton.Enabled && Map.LoginButton.Displayed))
            {
                Map.LoginButton.Click();
            }
        }

        public IEnumerable<string> GetAvailableUsernames()
        {
            IEnumerable<string> usernames = Map.ValidUsernames.Text.Split(separator: '\n', options: StringSplitOptions.TrimEntries);
            // Skipping the title
            usernames = usernames.Skip(1);
            return usernames;
        }
    }
}
