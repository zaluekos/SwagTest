using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SwagDriver;
using SwagDriverChrome;
using SwagDriverFirefox;

namespace SwagDriver
{
    public class DriverFactory : IDriverFactory
    {
        public IDriverManager CreateDriverManager(string browserName)
        {
            switch (browserName)
            {
                case SupportedBrowsers.CHROME:
                    return new ChromeDriverManager();
                case SupportedBrowsers.FIREFOX:
                    return new FirefoxDriverManager();
                default:
                    throw new NotSupportedException();
            }
        }

    }
}
