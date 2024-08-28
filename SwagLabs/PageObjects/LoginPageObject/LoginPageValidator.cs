using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SwagLabs.PageObjects.LoginPageObject
{
    // Validator for Login Page Object
    public class LoginPageValidator
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _waiter;

        protected LoginPageMap _map;
        public LoginPageValidator(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _waiter = new(_driver, TimeSpan.FromSeconds(5));
            _map = new(_driver);
        }

        public bool ThenErrorMessageShouldBe(string expectedMessage)
        {
            _waiter.Until(c => _map.PasswordField.Displayed);
            return _map.ErrorMessage.Text.Contains(expectedMessage);
        }

        public bool ThenLoginSuccessful()
        {
            try
            {
                if (_waiter.Until(c => _map.MainPageTitle.Displayed)
                    && _map.MainPageTitle.Text == "Swag Labs") return true;

                return false;
            }
            catch
            {
                return false;
            }

        }
    }
}