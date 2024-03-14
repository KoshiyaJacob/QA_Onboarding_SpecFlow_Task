using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SpecFlowProject_QA_MARS.Pages;

namespace SpecFlowProject_QA_MARS.StepDefinition
{
    [Binding]
    public class SkillsStep 
    {

        Skills Skill_Obj = new Skills();

//Add and duplication

        [Given(@"I logged in and click Skill tab")]
        public void GivenILoggedInAndClickSkillTab()
        {
            Skill_Obj.AddSkill();
            
        }

        [When(@"I add '([^']*)' mylevel '([^']*)'")]
        public void WhenIAddMylevel(string SkillKnown, string SkillLevel)
        {
            Skill_Obj.Skill_Level(SkillKnown, SkillLevel);
            
        }

        [Then(@"The '([^']*)'  should display")]
        public void ThenTheLevelShouldDisplay(string SkillKnown)
        {

            string notification = Skill_Obj.CheckSkillAdded(SkillKnown);

            string Message = SkillKnown + " has been added to your skills";
            string Duplicatedpopup = "Duplicated data";

            if (notification == (SkillKnown + "has been added to your skills"))
            {
                Assert.That(notification, Is.EqualTo(Message), notification);
            }

            else if (notification == "Duplicated data")
            {
                Console.WriteLine(SkillKnown + " " + notification);
                Assert.That(notification, Is.EqualTo(Duplicatedpopup), notification);
                
            }
        }

 //Edit

        [When(@"I edit last data into '([^']*)' level '([^']*)'")]
        public void WhenIEditLastDataIntoLevel(string SkillKnown, string SkillLevel)
        { 
            Skill_Obj.edit_Language(SkillKnown, SkillLevel);
        
        }

        [Then(@"The '([^']*)' should edited successfully")]
        public void ThenTheShouldEditedSuccessfully(string SkillKnown)
        {
            Skill_Obj.check_Skill_Updated(SkillKnown);
            string notification = Skill_Obj.check_Skill_Updated(SkillKnown);
            string Message = SkillKnown + " has been updated to your skills";
            Assert.That(notification, Is.EqualTo(Message),notification);
        }

//Delete

        [When(@"I delete '([^']*)'")]
        public void WhenIDelete(string SkillKnown)
        {
            Skill_Obj.Delete_Skill(SkillKnown);
        }

        [Then(@"The '([^']*)' deleted successfully")]
        public void ThenTheDeletedSuccessfully(string SkillKnown)
        {
            Skill_Obj.CheckDeletedSkill(SkillKnown);
            string notification = Skill_Obj.CheckDeletedSkill(SkillKnown);
            Assert.That(notification == (SkillKnown+" has been deleted"), notification);

        }
    }
}
