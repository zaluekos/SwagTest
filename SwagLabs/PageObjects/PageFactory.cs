using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwagDriver;
using OpenQA.Selenium;
using SwagLabs.PageObjects.LoginPageObject;

namespace SwagLabs.PageObjects
{
    public class PageFactory : IPageFactory
    {
        public ILoginPage CreateLoginPage(IWebDriver driver)
        {
            return new LoginPage(driver);
        }
    }
}