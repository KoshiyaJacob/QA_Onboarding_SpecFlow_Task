using OpenQA.Selenium;
using SpecFlowProject_QA_MARS.Utils;

namespace SpecFlowProject_QA_MARS.Pages
{
    public class Skills : Driver
    {


        // <summary>
        /// Holds constants for Profile page skill functionality.
        /// </summary>

        //Constants for Scenario 1. Verify user is able to add known skills with experience level
        public static IWebElement SkillFeatureButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
        public static IWebElement AddNewSkillButton => driver.FindElement(By.XPath("//div[@class='ui teal button']"));
        public static IWebElement AddSkillTextBox => driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        public static IWebElement SelectBeginnerProficiency => driver.FindElement(By.XPath("//option[@value='Beginner']"));
        public static IWebElement SelectIntermediateProficiency => driver.FindElement(By.XPath("//option[@value='Intermediate']"));
        public static IWebElement SelectExpertProficiency => driver.FindElement(By.XPath("//option[@value='Expert']"));
        public static IWebElement AddSkillButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        public static IWebElement LastAddedSkillAndLevel => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        //Constants for Scenario 2. Verify user is able to edit an existing known skill with experience level
        public static IWebElement EditSkillButton => driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody[last()]/tr[1]/td[3]/span[1]"));
        public static IWebElement SelectBeginnerExperienceForEdit => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select/option[2]"));
        public static IWebElement SelectIntermediateExperienceForEdit => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select/option[3]"));
        public static IWebElement SelectExpertExperienceForEdit => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select/option[4]"));
        public static IWebElement UpdateSkillButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[1]"));
        public static IWebElement UpdatedSkillAndLevel => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        //Constants for Scenario 3. Verify user is able to edit a experience level from the known language
        public static IWebElement EditSkillTextBox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[1]/input"));

        //Constants for Scenario 4. Verify user is able to delete an existing known skill
        public static IWebElement DeleteLastKnownSkill => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]"));
        public static IWebElement VerifyTheSkillIsDeletedFromTheProfile => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        //Constants for Scenario 5. Verify user attempting to add a language already present in the known languages list
        public static IWebElement VerifySkillIsNotDuplicated => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        //Constants for Scenario 6. Verify that the system rejects saving an empty skill field with the chosen experience level in the skill profile section
        public static IWebElement EmptyStringDisplayAnErrorMessageInTheSkillList => driver.FindElement(By.XPath("/html[1]/body[1]/div[1]"));




        /// <summary>
        /// Selects the skill feature from the my profile page
        /// </summary>
        /// <param name="driver"></param>
        public void ClickOnTheSkillFeature()
        {
            SkillFeatureButton.Click();
        }

        /// <summary>
        /// Adds a skills to the known skills list.
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="experienceLevel"></param>
        public void AddSkillsWithExperienceLevel(string skill, string experienceLevel)
        {
            try
            {
                AddNewSkillButton.Click();
                AddSkillTextBox.SendKeys(skill);
                SelectExperienceLevelForAdd(experienceLevel);
                AddSkillButton.Click();
            }
            catch (Exception)
            {
                Console.WriteLine("An exception occurred while adding a new skill and experience level.");
            }
        }

        /// <summary>
        /// Verifies the added skill with experiance level.
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="experienceLevel"></param>
        public Boolean VerifyTheAddedSkill(string skill, string experienceLevel)
        {
            Boolean VerifyTheAddedSkill = false;
            Thread.Sleep(5000);
            string expectedSkillAndExperience = LastAddedSkillAndLevel.Text;
            if (expectedSkillAndExperience.Contains(skill + " has been added to your skills"))
            {
                VerifyTheAddedSkill = true;
            }

            return VerifyTheAddedSkill;
        }

        /// <summary>
        /// Edits the skill and/or experiance level from the known skills list.
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="experienceLevel"></param>
        public void EditSkillExperienceLevel(string skill, string experienceLevel)
        {
            Thread.Sleep(2000);
            EditSkillButton.Click();
            if (!skill.Equals("skill", StringComparison.OrdinalIgnoreCase))
            {
                EditSkillTextBox.Clear();
                EditSkillTextBox.SendKeys(skill);
            }
            Thread.Sleep(2000);
            SelectExperienceLevelForEdit(experienceLevel);
            UpdateSkillButton.Click();
        }

        /// <summary>
        /// Verifies the updated skill with experience level.
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="experienceLevel"></param>
        public Boolean VerifytheUpdatedSkillExperienceLevel(string skill, string experienceLevel)
        {
            Boolean VerifytheUpdatedSkillExperienceLevel = false;
            Thread.Sleep(2000);
            string updatedSkillAndExperience = UpdatedSkillAndLevel.Text;
            if (updatedSkillAndExperience.Contains(skill))
            {
                VerifytheUpdatedSkillExperienceLevel = true;
            }
            else
            {
                VerifytheUpdatedSkillExperienceLevel = false;
            }

            return VerifytheUpdatedSkillExperienceLevel;
        }

        /// <summary>
        /// Deletes the skill from the known skills list.
        /// </summary>
        /// /// <param name="skill"></param>
        public void DeleteSkill(string skill)
        {
            Thread.Sleep(5000);
            DeleteLastKnownSkill.Click();
        }

        /// <summary>
        /// Verifies the skill is deleted.
        /// </summary>
        /// <param name="skill"></param>
        public Boolean VerifyTheSkillIsDeleted(string skill)
        {
            Boolean verifyTheSkillIsDeleted = false;
            Thread.Sleep(3000);
            if (VerifyTheSkillIsDeletedFromTheProfile.Text.Contains("has been deleted", StringComparison.OrdinalIgnoreCase))
            {
                verifyTheSkillIsDeleted = true;
            }

            return verifyTheSkillIsDeleted;
        }

        /// <summary>
        /// Adds a duplicated skill to the known languages list.
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="experienceLevel"></param>
        public void DuplicatedSkill(string skill, string experienceLevel)
        {
            Thread.Sleep(2000);
            AddNewSkillButton.Click();
            Thread.Sleep(1000);
            AddSkillTextBox.SendKeys(skill);
            Thread.Sleep(1000);
            SelectExperienceLevelForAdd(experienceLevel);
            AddSkillButton.Click();
        }

        /// <summary>
        /// Verifies if the skill has been duplicated.
        /// </summary>
        /// <param name="skill"></param>
        public Boolean VerifySkillNotDuplicated(string skill)
        {
            Boolean VerifySkillNotDuplicated = false;
            Thread.Sleep(2000);
            if (VerifySkillIsNotDuplicated.Text.Contains("This skill is already exist in your skill list.", StringComparison.OrdinalIgnoreCase))
            {
                VerifySkillNotDuplicated = true;
            }

            return VerifySkillNotDuplicated;
        }

        /// <summary>
        /// Verifies the skill with the same name but different cases.
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="experienceLevel"></param>
        public void SkillWithSameNameButdifferentCases(string skill, string experienceLevel)
        {
            Thread.Sleep(2000);
            AddNewSkillButton.Click();
            AddSkillTextBox.SendKeys(skill);
            SelectExperienceLevelForAdd(experienceLevel);
            AddSkillButton.Click();
        }

        /// <summary>
        /// Verifies if a skill is passed as an empty string displays an error message. 
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        public Boolean EmptyStringDisplayAnErrorMessageInTheSkill(string skill)
        {
            Boolean EmptyStringDisplayAnErrorMessageInTheSkill = false;
            Thread.Sleep(3000);
            if (EmptyStringDisplayAnErrorMessageInTheSkillList.Text.Contains("Please enter skill and experience" + " level", StringComparison.OrdinalIgnoreCase))
            {
                EmptyStringDisplayAnErrorMessageInTheSkill = true;
            }

            return EmptyStringDisplayAnErrorMessageInTheSkill;
        }

        /// <summary>
        /// Verifies the skill field contains only numbers.
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="experienceLevel"></param>
        public void SkillFieldWithNumbers(string skill, string experienceLevel)
        {
            Thread.Sleep(1000);
            AddNewSkillButton.Click();
            AddSkillTextBox.SendKeys(skill);
            SelectExperienceLevelForAdd(experienceLevel);
            AddSkillButton.Click();
        }
        /// <summary>
        ///  Verifies the skill field with special characters.
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="experienceLevel"></param>
        public void SkillFieldWithSpecialCharacters(string skill, string experienceLevel)
        {
            Thread.Sleep(1000);
            AddNewSkillButton.Click();
            AddSkillTextBox.SendKeys(skill);
            SelectExperienceLevelForAdd(experienceLevel);
            AddSkillButton.Click();
        }

        /// <summary>
        /// Verifies the skill with invalid experience level.
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="experienceLevel"></param>
        public void InValidExperienceLevel(string skill, string experienceLevel)
        {
            Thread.Sleep(1000);
            AddNewSkillButton.Click();
            AddSkillTextBox.SendKeys(skill);
            SelectExperienceLevelForAdd(experienceLevel);
            AddSkillButton.Click();
        }

        private void SelectExperienceLevelForAdd(string experienceLevel)
        {
            if (experienceLevel.Equals("beginner", StringComparison.OrdinalIgnoreCase))
            {
                SelectBeginnerProficiency.Click();
            }
            if (experienceLevel.Equals("intermediate", StringComparison.OrdinalIgnoreCase))
            {
                SelectIntermediateProficiency.Click();
            }
            if (experienceLevel.Equals("expert", StringComparison.OrdinalIgnoreCase))
            {
                SelectExpertProficiency.Click();
            }
        }

        private void SelectExperienceLevelForEdit(string experienceLevel)
        {
            if (experienceLevel.Equals("beginner", StringComparison.OrdinalIgnoreCase))
            {
                SelectBeginnerExperienceForEdit.Click();
            }
            if (experienceLevel.Equals("intermediate", StringComparison.OrdinalIgnoreCase))
            {
                SelectIntermediateExperienceForEdit.Click();
            }
            if (experienceLevel.Equals("expert", StringComparison.OrdinalIgnoreCase))
            {
                SelectExpertExperienceForEdit.Click();
            }
        }
    }
}




