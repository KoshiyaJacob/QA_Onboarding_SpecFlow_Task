using OpenQA.Selenium;
using SpecFlowProject_QA_MARS.Utils;

namespace SpecFlowProject_QA_MARS.Pages
{
    public class Languages : Driver

    {
        // Constructor
        public Languages()
        {
        }
        /// <summary>
        /// Holds constants for Profile page language functionality.
        /// </summary>

        //Constants for Scenario 1. Verify user is able to add known languages with proficiency level
        public static IWebElement AddNewButton => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        public static IWebElement AddLanguageTextBox => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
        public static IWebElement SelectBasicProficiency => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[2]"));
        public static IWebElement SelectConversationalProficiency => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[3]"));
        public static IWebElement SelectFluentProficiency => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[4]"));
        public static IWebElement SelectNativeProficiency => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[5]"));
        public static IWebElement AddLanguageButton => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
        public static IWebElement LastAddedLanguageAndLevel => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        //Constants for Scenario 2. Verify user is able to edit a proficiency level from the known language  
        public static IWebElement ClickOnTheEditButton => driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[last()]/tr[1]/td[3]/span[1]/i[1]"));
        public static IWebElement SelectBasicProficiencyForEdit => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[2]/select/option[2]"));
        public static IWebElement SelectConversationalProficiencyForEdit => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[2]/select/option[3]"));
        public static IWebElement SelectFluentProficiencyForEdit => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[2]/select/option[4]"));
        public static IWebElement SelectNativeProficiencyForEdit => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[2]/select/option[5]"));
        public static IWebElement UpdateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        public static IWebElement UpdatedLanguageAndLevel => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        //Constants for Scenario 3. Verify user is able to edit a proficiency level from the known language  
        public static IWebElement EditLanguageTextBox => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));

        //Constants for Scenario 4. Verify user is able to delete an existing known language
        public static IWebElement DeleteLastKnownLanguage => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]"));
        public static IWebElement VerifyTheLanguageIsDeletedFromTheProfile => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        //Constants for Scenario 5. Verify user attempting to add a language already present in the known languages list
        public static IWebElement VerifyLanguageIsNotDuplicated => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        //Constants for Scenario 6. Verify that the system rejects saving an empty language field with the chosen proficiency level in the language profile section
        public static IWebElement EmptyStringDisplaysAnErrorMessage => driver.FindElement(By.XPath("/html[1]/body[1]/div[1]"));

        /// <summary>
        /// Adds a language to the known laguages list.
        /// </summary>
        public void AddLanguageWithProficiencyLevel(string language, string proficiencyLevel)
        {
            try
            {
                AddNewButton.Click();
                AddLanguageTextBox.SendKeys(language);
                SelectProficiencyLevelForAdd(proficiencyLevel);
                AddLanguageButton.Click();
            }
            catch (Exception)
            {
                Console.WriteLine("An exception occurred while adding a new language and proficiency level.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="language"></param>
        /// <param name="proficiencyLevel"></param>
        /// <returns></returns>
        public Boolean VerifyTheAddedLanguage(string language, string proficiencyLevel)
        {
            Boolean VerifyTheAddedLanguage = false;
            Thread.Sleep(1000);
            string expectedLanguageAndProficiency = LastAddedLanguageAndLevel.Text;
            if (expectedLanguageAndProficiency.Contains(language + " has been added to your languages"))
            {
                VerifyTheAddedLanguage = true;
            }

            return VerifyTheAddedLanguage;
        }

        /// <summary>
        /// Edits the language and/or proficiency level from the known languages list.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="proficiencyLevel"></param>
        public void EditLanguageProficiencyLevel(string language, string proficiencyLevel)
        {
            Thread.Sleep(2000);
            ClickOnTheEditButton.Click();
            if (!language.Equals("language", StringComparison.OrdinalIgnoreCase))
            {
                EditLanguageTextBox.Clear();
                EditLanguageTextBox.SendKeys(language);
            }
            Thread.Sleep(2000);
            SelectProficiencyLevelForEdit(proficiencyLevel);
            UpdateButton.Click();
        }

        /// <summary>
        /// Verifies the updated language with proficiency level.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="proficiencyLevel"></param>
        public Boolean VerifyUpdatedLanguageProficiencyLevel(string language, string proficiencyLevel)
        {
            Boolean VerifyUpdatedLanguageProficiencyLevel = false;
            Thread.Sleep(2000);
            string updatedLanguageAndProficiency = UpdatedLanguageAndLevel.Text;
            if (updatedLanguageAndProficiency.Contains(language))
            {
                VerifyUpdatedLanguageProficiencyLevel = true;
            }
            else
            {
                VerifyUpdatedLanguageProficiencyLevel = false;
            }

            return VerifyUpdatedLanguageProficiencyLevel;
        }

        /// <summary>
        /// Deletes the language from the known languages list.
        /// </summary>
        /// <param name="language"></param>
        public void DeleteLanguage(string language)
        {
            Thread.Sleep(5000);
            DeleteLastKnownLanguage.Click();
        }

        /// <summary>
        /// Verifies the language is deleted. 
        /// </summary>
        /// <param name="language"></param>
        public Boolean VerifyTheLanguageIsDeleted(string language)
        {
            Boolean VerifyTheLanguageIsDeleted = false;
            Thread.Sleep(1500);
            if (VerifyTheLanguageIsDeletedFromTheProfile.Text.Contains("has been deleted from your languages", StringComparison.OrdinalIgnoreCase))
            {
                VerifyTheLanguageIsDeleted = true;
            }

            return VerifyTheLanguageIsDeleted;
        }

        /// <summary>
        /// Adds a duplicated language to the known languages list.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="proficiencyLevel"></param>
        public void DuplicatedLanguage(string language, string proficiencyLevel)
        {
            Thread.Sleep(2000);
            AddNewButton.Click();
            Thread.Sleep(2000);
            AddLanguageTextBox.SendKeys(language);
            Thread.Sleep(2000);
            SelectProficiencyLevelForAdd(proficiencyLevel);
            AddLanguageButton.Click();
        }

        /// <summary>
        /// Verifies if the language has been duplicated.
        /// </summary>
        /// <param name="language"></param>
        public Boolean VerifyLanguageNotDuplicated(string language)
        {
            Boolean VerifyLanguageNotDuplicated = false;
            Thread.Sleep(5000);
            if (VerifyLanguageIsNotDuplicated.Text.Contains("is already exist in your language list.", StringComparison.OrdinalIgnoreCase))
            {
                VerifyLanguageNotDuplicated = true;
            }

            return VerifyLanguageNotDuplicated;
        }

        /// <summary>
        /// Verifies if a language is passed as an empty string displays an error message. 
        /// </summary>
        /// <param name="language"></param>
        public Boolean EmptyStringDisplayAnErrorMessage(string language)
        {
            Boolean EmptyStringDisplayAnErrorMessage = false;
            Thread.Sleep(3000);
            if (EmptyStringDisplaysAnErrorMessage.Text.Contains("Please enter language and level", StringComparison.OrdinalIgnoreCase))
            {
                EmptyStringDisplayAnErrorMessage = true;
            }

            return EmptyStringDisplayAnErrorMessage;
        }

        /// <summary>
        /// Verifies the language with the same name but different cases.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="proficiencyLevel"></param>
        public void LanguageWithSameNameButdifferentCases(string language, string proficiencyLevel)
        {
            Thread.Sleep(2000);
            AddNewButton.Click();
            AddLanguageTextBox.SendKeys(language);
            SelectProficiencyLevelForAdd(proficiencyLevel);
            AddLanguageButton.Click();
        }

        /// <summary>
        /// Verifies the language field with the numbers.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="proficiencyLevel"></param>
        public void LanguageFieldContainsNumber(string language, string proficiencyLevel)
        {
            Thread.Sleep(1000);
            AddNewButton.Click();
            AddLanguageTextBox.SendKeys(language);
            SelectProficiencyLevelForAdd(proficiencyLevel);
            AddLanguageButton.Click();
        }

        /// <summary>
        /// Verifies the language field with special characters.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="proficiencyLevel"></param>
        public void LanguageFieldContainsSpecialCharacter(string language, string proficiencyLevel)
        {
            Thread.Sleep(1000);
            AddNewButton.Click();
            AddLanguageTextBox.SendKeys(language);
            SelectProficiencyLevelForAdd(proficiencyLevel);
            AddLanguageButton.Click();
        }

        /// <summary>
        /// Verifies the language with invalid proficiency level.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="proficiencyLevel"></param>
        public void InvalidProficiencyLevel(string language, string proficiencyLevel)
        {
            Thread.Sleep(1000);
            AddNewButton.Click();
            AddLanguageTextBox.SendKeys(language);
            SelectProficiencyLevelForAdd(proficiencyLevel);
            AddLanguageButton.Click();
        }

        private void SelectProficiencyLevelForAdd(string proficiencyLevel)
        {
            if (proficiencyLevel.Equals("basic", StringComparison.OrdinalIgnoreCase))
            {
                SelectBasicProficiency.Click();
            }
            if (proficiencyLevel.Equals("conversational", StringComparison.OrdinalIgnoreCase))
            {
                SelectConversationalProficiency.Click();
            }
            if (proficiencyLevel.Equals("fluent", StringComparison.OrdinalIgnoreCase))
            {
                SelectFluentProficiency.Click();
            }
            if (proficiencyLevel.Equals("native", StringComparison.OrdinalIgnoreCase))
            {
                SelectNativeProficiency.Click();
            }
        }

        private void SelectProficiencyLevelForEdit(string proficiencyLevel)
        {
            if (proficiencyLevel.Equals("basic", StringComparison.OrdinalIgnoreCase))
            {
                SelectBasicProficiencyForEdit.Click();
            }
            if (proficiencyLevel.Equals("conversational", StringComparison.OrdinalIgnoreCase))
            {
                SelectConversationalProficiencyForEdit.Click();
            }
            if (proficiencyLevel.Equals("fluent", StringComparison.OrdinalIgnoreCase))
            {
                SelectFluentProficiencyForEdit.Click();
            }
            if (proficiencyLevel.Equals("native", StringComparison.OrdinalIgnoreCase))
            {
                SelectNativeProficiencyForEdit.Click();
            }
        }

    }
}

