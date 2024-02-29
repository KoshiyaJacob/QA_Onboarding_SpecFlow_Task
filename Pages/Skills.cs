using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SpecFlowProject_QA_MARS;
using SpecFlowProject_QA_MARS.Utils;

namespace SpecFlowProject_QA_MARS.Pages
{
    public class Skills : Start
    {
 //Add Locator
        By Skill_Tab = By.LinkText("Skills");

        By Add_New_Button = By.XPath("(//div[@class='ui teal button'])[1]");

        By Language_TextBox = By.XPath("//input[@placeholder='Add Skill']");

        By Level_Dropdown = By.XPath("//select[@name='level']");

        By Add_Button = By.XPath("//input[@value='Add']");

//Edit Locator
        By edit_Icon = By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[3]/span[1]");

        By edit_TextBox = By.XPath("//input[@placeholder='Add Skill']");

        By update_Button = By.XPath("//input[@value='Update']");

// Delete Locator
        By delete_Button = By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[3]/span[2]");

     //popup locator
        By Popup_Message = By.XPath("//div[@class='ns-box-inner']");


     //Add and Duplicate:
        public void AddSkill()
        {
            Wait.WaitToBeVisible(driver, "LinkText", "Skill_Tab",20 );
            driver.FindElement(Skill_Tab).Click();
        }

        public void Skill_Level(string SkillKnown, string SkillLevel)
        {
            
            driver.FindElement(Add_New_Button).Click();

            driver.FindElement(Language_TextBox).SendKeys(SkillKnown);
            

            Wait.WaitToBeVisible(driver, "Xpath", "SelectedLevel", 10);

            SelectElement selectedLevel = new SelectElement(driver.FindElement(Level_Dropdown));
            selectedLevel.SelectByValue(SkillLevel);
            

            driver.FindElement(Add_Button).Click();
        }

        public string CheckSkillAdded(string SkillKnown)
        {
            
            Wait.WaitToBeVisible(driver, "Xpath", "Popup-Message", 10);
            string successMessage = driver.FindElement(Popup_Message).Text;
            return successMessage;
        }  

    //Edit
        
        public void edit_Language(String SkillKnown , String SkillLevel)
        {
            
            driver.FindElement(edit_Icon).Click();
            driver.FindElement(edit_TextBox).Clear();

            driver.FindElement(edit_TextBox).SendKeys(SkillKnown);
            

            Wait.WaitToBeVisible(driver, "Xpath", "SelectedLevel", 10);

            SelectElement selectedLevel = new SelectElement(driver.FindElement(Level_Dropdown));
            selectedLevel.SelectByValue(SkillLevel);

            driver.FindElement(update_Button).Click();
        }

        public string check_Skill_Updated(String SkillKnown) 
        {
            
            Wait.WaitToBeVisible(driver, "Xpath", "Popup-Message", 10);
            string EditMessage = driver.FindElement(Popup_Message).Text;
            return EditMessage;
        }

    //Delete
        public void Delete_Skill(string SkillKnown)
        {
            driver.FindElement(delete_Button).Click();
        }
        
        public string CheckDeletedSkill(string SkillKnown)
        {
            
            string DeleteMessage = driver.FindElement(Popup_Message).Text;
            return DeleteMessage;
        }
    }
}
