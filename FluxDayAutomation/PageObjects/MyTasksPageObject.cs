using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace FluxDayAutomation.PageObjects
{
    public class MyTasksPageObject
    {
        private const string MY_TASKS_TITLE_LABEL_CSS = "#pane2 > div.pane2-meta > div";
        private const string PENDING_TASK_LINK_CSS = "#pane2 > div.pane2-meta > dl > dd.active.clear-tab > a";
        private const string COMPLETED_TASK_LINK_CSS = "#pane2 > div.pane2-meta > dl > dd:nth-child(2) > a";
        private const string TASKS_PARENT_PANEL_ID = "paginator";
        private const string TASK_LINK_TAGNAME = "a";
        private const string TASK_CLASSNAME = "name";
        private const int EXPLICIT_WAIT_SECONDS = 10;

        private IWebDriver driver;
        private WebDriverWait wait;

        public MyTasksPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement MyTasksTitleLabel
        {
            get => driver.FindElement(By.CssSelector(MY_TASKS_TITLE_LABEL_CSS));
        }

        public IWebElement PendingTasksLink
        {
            get => driver.FindElement(By.CssSelector(PENDING_TASK_LINK_CSS));
        }

        public IWebElement CompletedTasksLink
        {
            get => driver.FindElement(By.CssSelector(COMPLETED_TASK_LINK_CSS));
        }

        public List<TaskPageObject> TaskList
        {
            get
            {
                // Waiting until task appears 
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(EXPLICIT_WAIT_SECONDS));
                wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(TASK_CLASSNAME)));

                var result = new List<TaskPageObject>();
                var panel = driver.FindElement(By.Id(TASKS_PARENT_PANEL_ID));
                var tasks = panel.FindElements(By.TagName(TASK_LINK_TAGNAME));

                foreach (var task in tasks)
                {
                    result.Add(new TaskPageObject(task));
                }

                return result;
            }
        }
    }
}