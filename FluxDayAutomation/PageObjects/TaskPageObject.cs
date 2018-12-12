using OpenQA.Selenium;

namespace FluxDayAutomation.PageObjects
{
    public class TaskPageObject
    {
        IWebElement parent;

        private const string TASK_NAME_CLASS = "name";
        private const string TASK_END_DATE_CLASS = "date";
        private const string TEAM_NAME_CLASS = "team";
        private const string TASK_ICON_CLASS = "icon";

        public TaskPageObject(IWebElement parent)
        {
            this.parent = parent;
        }

        public IWebElement TaskName
        {
            get => parent.FindElement(By.ClassName(TASK_NAME_CLASS));
        }

        public IWebElement TaskEndDate
        {
            get => parent.FindElement(By.ClassName(TASK_END_DATE_CLASS));
        }

        public IWebElement TeamName
        {
            get => parent.FindElement(By.ClassName(TEAM_NAME_CLASS));
        }

        public IWebElement TaskIcon
        {
            get => parent.FindElement(By.ClassName(TASK_ICON_CLASS));
        }
    }
}
