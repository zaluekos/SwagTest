using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwagDriverChrome;
using SwagDriver;
using SwagLabs.PageObjects.LoginPageObject;
using SwagLabs;
using SwagTesting;

[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]
namespace SwagLabsTests
{

    [TestClass]
    public class LoginTests
    {
        private IDriverManager driverManager;
        private static IEnumerable<object[]> CredentialsTestData
        {
            get
            {
                var driver = new ChromeDriverManager();
                var lPage = new LoginPage(driver.GetDriver());
                lPage.Navigate();

                var res = LoginTestData.GetLoginWithValidCredentials(lPage.GetAvailableUsernames());

                driver.QuitDriver();
                return res;
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(LoginTestData.GetSupportedBrowsers), typeof(LoginTestData), DynamicDataSourceType.Property)]
        public void GivenAnyCredentials_WhenCredentialsEntered_AndCredentialsCleared_AndLoginButtonClicked_ThenErrorMessageShouldBe(string browserName)
        {
            driverManager = new DriverFactory().CreateDriverManager(browserName);
            var driver = driverManager.CreateDriver();
            if (driver is null) throw new Exception("Driver not set");

            var steps = new LoginTestSteps(new LoginPage(driver));

            steps.GivenAnyCredentials();

            steps.WhenEnteredAnyCredentials();
            steps.AndClearedAllCredentials();
            steps.AndLoginButtonPressed();

            steps.ThenErrorMessageShouldBe("Username is required").Should().BeTrue(because: "Username should be entered");
        }

        [DataTestMethod]
        [DynamicData(nameof(LoginTestData.GetSupportedBrowsers), typeof(LoginTestData), DynamicDataSourceType.Property)]
        public void GivenAnyCredentials_WhenCredentialsEntered_AndPasswordCleared_AndLoginButtonClicked_ThenErrorMessageShouldBe(string browserName)
        {
            driverManager = new DriverFactory().CreateDriverManager(browserName);
            var driver = driverManager.CreateDriver();
            if (driver is null) throw new Exception("Driver not set");

            var steps = new LoginTestSteps(new LoginPage(driver));

            steps.GivenAnyCredentials();

            steps.WhenEnteredAnyCredentials();
            steps.AndClearedPassword();
            steps.AndLoginButtonPressed();

            steps.ThenErrorMessageShouldBe("Password is required").Should().BeTrue(because: "Username should be entered");
        }

        [DataTestMethod]
        [DynamicData(nameof(CredentialsTestData), DynamicDataSourceType.Property)]
        public void GivenValidCredentials_WhenCredentialsEntered_AndLoginButtonClicked_ThenLoginSuccessful(string browserName, string givenUsername)
        {
            string validPassword = "secret_sauce";
            driverManager = new DriverFactory().CreateDriverManager(browserName);
            var driver = driverManager.CreateDriver();
            if (driver is null) throw new Exception("Driver not set");

            var steps = new LoginTestSteps(new LoginPage(driver));

            steps.GivenValidCredentials(givenUsername, validPassword);

            steps.WhenEnteredValidCredentials();
            steps.AndLoginButtonPressed();

            steps.ThenLoginShouldBeSuccessful().Should().BeTrue(because: "Login should be successful with valid credentials");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driverManager.QuitDriver();
        }
    }
}