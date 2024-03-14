using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject_QA_MARS.Utils;

namespace SpecFlowProject_QA_MARS.Pages
{
    public class Languages : Start
    {
//Adding and duplicating locators

        By languageTab = By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]");

        By addNewBtn = By.XPath("//div[@data-tab='first']//div[@class ='ui teal button ']");

        By language_Data = By.XPath("//input[@placeholder='Add Language']");

        By level_Dropdown = By.XPath("//select[@name='level']");

        By add_Language = By.XPath("//input[@value='Add']");

//Edit locators

        By edit_Button = By.XPath("//div[@data-tab='first']//tbody[last()]/tr/td[3]/span[1]/i");

        By editLanguage = By.XPath("//input[@placeholder='Add Language']");

        By update_Button = By.XPath("//input[@value='Update']");

//Delete locators

        By deleteButton = By.XPath("//div[@data-tab='first']//tbody[last()]/tr/td[3]/span[2]/i");

//Popup Locator

        By popup_Message = By.XPath("//div[@class=\"ns-box-inner\"]");


 //Adding and Duplication Languages method
        public void Click_Language_Tab()
        {
            Wait.WaitToBeVisible(driver, "Xpath", "languageTab", 10);
            driver.FindElement(languageTab).Click();
        }

        public void Click_AddNew_Btn()
        {
            Wait.WaitToBeVisible(driver, "Xpath", "addNewBtn", 10);
            driver.FindElement(addNewBtn).Click();

        }
        public void Language_Data(string LanguageKnown, string MyLevel)
        {
            driver.FindElement(language_Data).Click();
            driver.FindElement(language_Data).Clear();

            driver.FindElement(language_Data).SendKeys(LanguageKnown);
            
            Wait.WaitToBeVisible(driver, "Xpath", "SelectedLevel", 10);
            SelectElement selectedLevel = new SelectElement(driver.FindElement(level_Dropdown));
            selectedLevel.SelectByValue(MyLevel);

        }
        public void Add_New_Lang()
        {
            driver.FindElement(add_Language).Click();
        }

        public string CheckNewLanguageAdded(string LanguageKnown)
        {
            
            Wait.WaitToBeVisible(driver, "Xpath", "popup-Message", 10);
            string successMessage = driver.FindElement(popup_Message).Text;
            return successMessage;
        }

 //Editing Laanguages method

        public void Edit_Language(string LanguageKnown, String MyLevel)
        {
            
            driver.FindElement(edit_Button).Click();
            
            driver.FindElement(editLanguage).Clear();
            driver.FindElement(editLanguage).SendKeys(LanguageKnown);

            
            SelectElement selectedLevel = new SelectElement(driver.FindElement(level_Dropdown));
            selectedLevel.SelectByValue(MyLevel);
            driver.FindElement(update_Button).Click();
        }

        public string CheckUpdatedLang(String LanguageKnown)
        {
            
            string EditMessage = driver.FindElement(popup_Message).Text;
            return EditMessage;

        }
//Deleting Languages
        public void Delete_Language(string LanguageKnown)
        {
            
            driver.FindElement(deleteButton).Click();

        }
        public string CheckDeletedLang(string LanguageKnown)
        {
            
            string DeleteMessage = driver.FindElement(popup_Message).Text;
            return DeleteMessage;
        }

    }
}
