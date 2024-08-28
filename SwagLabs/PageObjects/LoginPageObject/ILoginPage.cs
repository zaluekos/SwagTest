using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SwagLabs.PageObjects.LoginPageObject
{
    public interface ILoginPage
    {
        public LoginPageMap Map { get; }
        public LoginPageValidator Validator { get; }
        public void Navigate();
        public void WhenEnteredUsernameIs(string username);
        public void WhenEnteredPasswordIs(string password);
        public void WhenElementCleared(IWebElement element);
        public void WhenLoginButtonPressed();
        public IEnumerable<string> GetAvailableUsernames();
    }
}