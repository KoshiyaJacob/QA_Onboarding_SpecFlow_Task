using OpenQA.Selenium;
using SpecFlowProject_QA_MARS.Utils;

namespace SpecFlowProject_QA_MARS.Pages
{

    public class SigninPage : Driver
    {
        // Constructor
        public SigninPage()
        {
        }
        private IWebElement signInButton => driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div[1]/div/a"));
        private IWebElement emailAddressTextBox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
        private IWebElement passwordTextBox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
        private IWebElement loginButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));

        /// <summary>
        /// Method to sign in to the application using the required credentials.
        /// </summary>
        public void SignInToApplication()
        {
            Driver.NavigateToApplicationUrl(driver);
            signInButton.Click();
            emailAddressTextBox.SendKeys("koshiyajacob@gmail.com");
            passwordTextBox.SendKeys("Godislove@1");
            loginButton.Click();
        }

    }
}


