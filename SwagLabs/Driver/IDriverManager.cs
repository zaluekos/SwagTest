using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SwagDriver
{
    public interface IDriverManager
    {
        public IWebDriver CreateDriver();
        public IWebDriver GetDriver();
        public void QuitDriver();

    }
}
