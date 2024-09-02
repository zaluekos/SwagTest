using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwagDriver;

namespace SwagTesting
{
    public static class LoginTestData
    {
        public static IEnumerable<object[]> GetSupportedBrowsers()
        {
            List<object[]> result = new List<object[]>();
            foreach (string browser in SupportedBrowsers.Browsers)
            {
                result.Add(new object[] { browser });
            }
            return result;
        }

        public static IEnumerable<object[]> GetLoginWithValidCredentials(IEnumerable<string> availableUsernames)
        {
            List<object[]> result = new List<object[]>();
            foreach (string browser in SupportedBrowsers.Browsers)
            {
                foreach (string username in availableUsernames)
                {
                    result.Add(new object[] { browser, username });
                }
            }
            return result;
        }
    }
}