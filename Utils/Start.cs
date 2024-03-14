
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProject_QA_MARS.Pages;


namespace SpecFlowProject_QA_MARS.Utils
{   public class Start 
    {
 //common driver and login functionality

        public static IWebDriver driver;

        private By Sign_In = By.LinkText("Sign In");
        private By Email_Field = By.XPath("//input[contains(@name,'email')]");
        private By Password_Field = By.XPath("//input[contains(@name,'password')]");
        private By Login_Button = By.XPath("//button[contains(text(),'Login')]");
        
        public void Setup()
        {
            driver = new ChromeDriver(); 
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.FindElement(Sign_In).Click();
            driver.FindElement(Email_Field).SendKeys("koshiya14@gmail.com");
            driver.FindElement(Password_Field).SendKeys("Godislove@1");
            driver.FindElement(Login_Button).Click();
            Thread.Sleep(5000);
        }

        public void TearDown()
        {
            driver.Close();
         
        }
    }
}
