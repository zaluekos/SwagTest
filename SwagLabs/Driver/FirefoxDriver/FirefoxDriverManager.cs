using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SwagDriver;

namespace SwagDriverFirefox
{
    public class FirefoxDriverManager : IDriverManager
    {
        private FirefoxDriver? _driver;
        public IWebDriver CreateDriver()
        {
            if (_driver is null)
            {
                _driver = new FirefoxDriver();
                return _driver;

            }
            else
            {
                return GetDriver();
            }
        }

        public IWebDriver GetDriver()
        {
            if (_driver is null)
            {
                CreateDriver();
            }

            return _driver;
        }

        public void QuitDriver()
        {
            if (_driver is not null)
            {
                _driver.Quit();
                _driver = null;
            }
        }
    }
}