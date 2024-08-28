using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SwagLabs.PageObjects.LoginPageObject
{
    public class LoginPageMap
    {
        private readonly IWebDriver _driver;
        public LoginPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement UsernameField => _driver.FindElement(By.CssSelector("input#user-name"));
        public IWebElement PasswordField => _driver.FindElement(By.CssSelector("input#password"));
        public IWebElement LoginButton => _driver.FindElement(By.CssSelector("input#login-button"));
        public IWebElement ErrorMessage => _driver.FindElement(By.CssSelector("h3[data-test='error']"));
        public IWebElement ValidUsernames => _driver.FindElement(By.CssSelector("div#login_credentials"));
        public IWebElement MainPageTitle => _driver.FindElement(By.CssSelector("div.app_logo"));
    }
}
