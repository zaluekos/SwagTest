﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using FluentAssertions;
using SwagDriverChrome;
using SwagDriver;
using static SwagDriver.SupportedBrowsers;
using SwagLabs.PageObjects.LoginPageObject;
using SwagLabs;
using SwagTesting;
using static SwagTesting.LoginTestData;
using Xunit;
//using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SwagLabsTests
{
    public class TestFixture : IDisposable
    {
        public TestFixture()
        {

        }

        public void Dispose()
        {

        }
    }
    public class LoginTests : IClassFixture<TestFixture>, IDisposable
    {
        private IDriverManager driverManager;
        public static IEnumerable<object[]> CredentialsTestData
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

        private readonly TestFixture _fixture;

        public LoginTests(TestFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [MemberData(nameof(LoginTestData.GetSupportedBrowsers), MemberType = typeof(LoginTestData))]
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

        [Theory]
        [MemberData(nameof(LoginTestData.GetSupportedBrowsers), MemberType = typeof(LoginTestData))]
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

        [Theory]
        [MemberData(nameof(CredentialsTestData))]
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

        public void Dispose()
        {
            driverManager.QuitDriver();
        }
    }

}
