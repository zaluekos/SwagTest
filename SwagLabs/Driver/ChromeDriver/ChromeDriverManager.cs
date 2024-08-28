using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SwagDriver;

namespace SwagDriverChrome
{
    public class ChromeDriverManager : IDriverManager
    {
        private ChromeDriver? _driver;
        public IWebDriver CreateDriver()
        {
            if (_driver is null)
            {
                _driver = new ChromeDriver();
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