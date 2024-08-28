using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using SwagLabs.PageObjects.LoginPageObject;

namespace SwagTesting
{
    public class LoginTestSteps
    {
        private static Logger logger = LogManager.GetLogger("FileLog");
        private readonly ILoginPage _loginPage;
        private readonly LoginForm _loginForm;
        public LoginTestSteps(ILoginPage loginPage)
        {
            try
            {
                _loginPage = loginPage;
                _loginPage.Navigate();
                _loginForm = new LoginForm();
                logger.Info("Navigated to Login page.");
            }
            catch
            {
                logger.Error("Navigating to Login page failed");
            }
        }

        public void GivenAnyCredentials()
        {
            _loginForm.Username = "random username";
            _loginForm.Password = "random password";

            logger.Info($"Given {_loginForm.Username} username and {_loginForm.Password} password");
        }
        public void GivenValidCredentials(string validUsername, string validPassword)
        {
            _loginForm.Username = validUsername;
            _loginForm.Password = validPassword;

            logger.Info($"Given {_loginForm.Username} username and {_loginForm.Password} password");
        }
        public void WhenEnteredAnyCredentials()
        {
            try
            {
                _loginPage.WhenEnteredUsernameIs(_loginForm.Username);
                _loginPage.WhenEnteredPasswordIs(_loginForm.Password);
                logger.Info($"Entered {_loginForm.Username} and {_loginForm.Password} as any credentials to forms");
            }

            catch
            {
                logger.Error("Entering credentials failed");
            }
        }
        public void AndClearedAllCredentials()
        {
            _loginPage.WhenElementCleared(_loginPage.Map.UsernameField);
            _loginPage.WhenElementCleared(_loginPage.Map.PasswordField);
            logger.Info("All credentials cleared");
        }
        public void AndClearedPassword()
        {
            _loginPage.WhenElementCleared(_loginPage.Map.PasswordField);
            logger.Info("Password field cleared");
        }
        public void WhenEnteredValidCredentials()
        {
            try
            {
                _loginPage.WhenEnteredUsernameIs(_loginForm.Username);
                _loginPage.WhenEnteredPasswordIs(_loginForm.Password);
                logger.Info($"Entered {_loginForm.Username} and {_loginForm.Password} as valid credentials to forms.");
            }
            catch
            {
                logger.Error("Entering credentials failed.");
            }
        }
        public void AndLoginButtonPressed()
        {
            try
            {
                _loginPage.WhenLoginButtonPressed();
                logger.Info("Pressed login button.");
            }
            catch
            {
                logger.Error("Could not login.");
            }
        }
        public bool ThenErrorMessageShouldBe(string message)
        {
            bool isErrorShown = _loginPage.Validator.ThenErrorMessageShouldBe(message);
            if (isErrorShown)
            {
                logger.Info("Login successful!");
                return true;
            }

            logger.Error("Login could not be successful...");
            return false;
        }
        public bool ThenLoginShouldBeSuccessful()
        {
            bool isLoginSuccessful = _loginPage.Validator.ThenLoginSuccessful();
            if (isLoginSuccessful)
            {
                logger.Info("Login successful!");
                return isLoginSuccessful;
            }

            logger.Error("Login could not be successful...");
            return false;
        }
    }

    public class LoginForm
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}