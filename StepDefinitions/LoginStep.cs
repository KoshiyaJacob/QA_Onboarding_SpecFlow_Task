using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProject_QA_MARS;
using SpecFlowProject_QA_MARS.Pages;
using SpecFlowProject_QA_MARS.Utils;

namespace SpecFlowProject_QA_MARS.StepDefinition
{ 
    [Binding]  
    public class LoginStep : Start
    {

        SignIn SignInObj = new SignIn();

       

        [Given(@"Login to the Profile page using valid credentials")]
        public void GivenLoginToTheProfilePageUsingValidCredentials()
        {
            SignInObj.LoginFunction();
        }





    }
}
