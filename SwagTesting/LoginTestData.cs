using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwagDriver;

namespace SwagTesting
{
    // Data for tests execution
    public static class LoginTestData
    {
        public static IEnumerable<object[]> GetSupportedBrowsers
        {
            get
            {
                List<object[]> result = [];
                foreach (string browser in SupportedBrowsers.Browsers)
                {
                    result.Add([browser]);
                }
                return result;
            }

        }
        public static IEnumerable<object[]> GetLoginWithValidCredentials(IEnumerable<string> availableUsernames)
        {
            List<object[]> result = [];
            foreach (string browser in SupportedBrowsers.Browsers)
            {
                foreach (string username in availableUsernames)
                {
                    result.Add([browser, username]);
                }
            }

            return result;
        }
    }
}