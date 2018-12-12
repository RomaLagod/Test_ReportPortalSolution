using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FluxDayAutomation.PageObjects
{
    public class AddTaskPageObject
    {
        private const string CREATE_TASK_BUTTON_CSS = "#new_task > div.small-12.columns.form-action-up > div.right > input";
        private const string CANCEL_LINK_CSS = "#new_task > div.small-12.columns.form-action-up > div.right > a";
        private const string TASK_NAME_ID = "task_name";
        private const string TASK_DESCRIPTION_ID = "task_description";
        private const string TEAM_LIST_ID = "task_team_id";
        private const string TASK_START_DATE_ID = "task_start_date";
        private const string TASK_END_DATE_ID = "task_end_date";
        private const string TASK_PRIORITY_LIST_ID = "task_priority";
        private const string USER_KEY_RESULTS_CLASS = "user-krs";
        private const string TEAM_FIELD_CSS = "#s2id_task_team_id > a";
        private const string TEAM_INPUT_CSS = "#select2-drop > div > input";
        private const string EXECUTE_SCRIPT = "return (document.readyState == 'complete' && jQuery.active == 0)";
        private const int EXPLICIT_WAIT_SECONDS = 10;

        private WebDriverWait wait;
        private IWebDriver driver;

        public AddTaskPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement CreateTaskButton
        {
            get => driver.FindElement(By.CssSelector(CREATE_TASK_BUTTON_CSS));
        }

        public IWebElement CancelLink
        {
            get => driver.FindElement(By.CssSelector(CANCEL_LINK_CSS));
        }

        public IWebElement TaskTitle
        {
            get
            {
                // Waiting until field for task name appears 
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(EXPLICIT_WAIT_SECONDS));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(TASK_NAME_ID)));

                return driver.FindElement(By.Id(TASK_NAME_ID));
            }
        }

        public IWebElement TaskDescription
        {
            get => driver.FindElement(By.Id(TASK_DESCRIPTION_ID));
        }

        public SelectElement TeamListComboBox
        {
            get => new SelectElement(driver.FindElement(By.Id(TEAM_LIST_ID)));
        }

        public IWebElement TaskStartDate
        {
            get => driver.FindElement(By.Id(TASK_START_DATE_ID));
        }

        public IWebElement TaskEndDate
        {
            get => driver.FindElement(By.Id(TASK_END_DATE_ID));
        }

        public SelectElement TaskPriorityListComboBox
        {
            get => new SelectElement(driver.FindElement(By.Id(TASK_PRIORITY_LIST_ID)));
        }

        public IWebElement TeamField
        {
            get => driver.FindElement(By.CssSelector(TEAM_FIELD_CSS));
        }

        public IWebElement TeamInput
        {
            get
            {
                // Waiting until input field for team name appears 
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(EXPLICIT_WAIT_SECONDS));
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(TEAM_INPUT_CSS)));

                return driver.FindElement(By.CssSelector(TEAM_INPUT_CSS));
            }
        }

        public List<UserKeyResultsPageObject> AssigneesList
        {
            get
            {
                var result = new List<UserKeyResultsPageObject>();

                // Waiting until first User's Key Results list appears (they appear not instantly)
                var javaScriptExecutor = driver as IJavaScriptExecutor;
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(EXPLICIT_WAIT_SECONDS));
                wait.Until(driver => (bool)javaScriptExecutor.ExecuteScript(EXECUTE_SCRIPT));

                // Finding ALL Users' Key Results lists
                var users = driver.FindElements(By.ClassName(USER_KEY_RESULTS_CLASS));

                foreach (var element in users)
                {
                    result.Add(new UserKeyResultsPageObject(element));
                }

                return result;
            }
        }
    }
}
