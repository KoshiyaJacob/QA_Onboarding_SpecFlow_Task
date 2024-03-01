using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyModel;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject_QA_MARS.Pages;
using SpecFlowProject_QA_MARS.Utils;

namespace SpecFlowProject_QA_MARS.StepDefinitions
{

    [Binding]
    public class LanguageLevel : Start
    {
        Languages LangObj = new Languages();


        [Given(@"I navigate to Language")]
        public void GivenINavigateToLanguage()
        {
            LangObj.Click_Language_Tab();
            

        }

        [When(@"I add '([^']*)' my level '([^']*)' in profile")]
        public void WhenIAddMyLevelInProfile(string LanguageKnown, string myLevel)
        {
            LangObj.Click_AddNew_Btn();
            LangObj.Language_Data(LanguageKnown, myLevel);
            LangObj.Add_New_Lang();
        }

        //Adding

        [Then(@"The new '([^']*)' should display")]
        public void ThenTheNewShouldDisplay(string LanguageKnown)
        {
            
            string notification = LangObj.CheckNewLanguageAdded(LanguageKnown);
            String Message = LanguageKnown + " has been added to your languages";
            String DuplicateMess = "Duplicated data";

            if (notification == (LanguageKnown + " has been added to your languages"))
            { Assert.That(notification, Is.EqualTo(Message), notification);
            }              
            
            else if (notification == "Duplicated data")
            { 
                Assert.That(notification, Is.EqualTo(DuplicateMess), notification);
                Console.WriteLine(LanguageKnown +" " + notification);

            }
                

     
                  
        }

        // Edit


        [When(@"I edit the second '([^']*)' with new '([^']*)'")]
        public void WhenIEditTheSecondWithNew(string LanguageKnown, string MyLevel)
        {
            LangObj.Edit_Language(LanguageKnown, MyLevel);
        }

        [Then(@"The '([^']*)' should be updated")]
        public void ThenTheAndShouldBeUpdated(string LanguageKnown)
        {
            LangObj.CheckUpdatedLang(LanguageKnown);
            string notification = LangObj.CheckUpdatedLang(LanguageKnown);
            string Message = LanguageKnown + " has been updated to your languages";
            Assert.That(notification, Is.EqualTo(Message), notification);
        }

        //Delete

        [When(@"I delete an existing '([^']*)'")]
        public void WhenIDeleteAnExisting(string LanguageKnown)
        {
            LangObj.Delete_Language(LanguageKnown);

        }

        [Then(@"the existing '([^']*)' should be deleted")]
        public void ThenTheExistingShouldBeDeleted(string LanguageKnown)
        {
            LangObj.CheckDeletedLang(LanguageKnown);
            string notification = LangObj.CheckDeletedLang(LanguageKnown);
            Assert.That(notification == (LanguageKnown + " has been deleted from your languages"), notification);
        }
    }
}
