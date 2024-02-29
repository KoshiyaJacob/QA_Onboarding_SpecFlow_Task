using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject_QA_MARS;
using SpecFlowProject_QA_MARS.Utils;

namespace SpecFlowProject_QA_MARS.Pages
{
    public class SignIn : Start
    {
        

         private By Profile_Verification = By.XPath("//a[contains(text(),'Mars Logo')]");


        public void LoginFunction( )
        {
            
         

            String verification_Text = driver.FindElement(Profile_Verification).Text;
            Assert.That(verification_Text, Is.EqualTo("Mars Logo"));
            Console.WriteLine(verification_Text);
           




        }

        
    }
}
