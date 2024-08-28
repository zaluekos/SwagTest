using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagDriver
{
    public static class SupportedBrowsers
    {
        public static IEnumerable<string> Browsers => [CHROME, FIREFOX];
        public const string CHROME = "chrome";
        public const string FIREFOX = "firefox";
    }
}