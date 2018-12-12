using OpenQA.Selenium;

namespace FluxDayAutomation.PageObjects
{
    public class TeamPageObject
    {
        private const string TEAM_NAME_XPATH = ".div[1]/a";
        private const string AMOUNT_OF_MEMBERS_XPATH = ".div[2]";
        private const string TEAM_DEPARTMENT_XPATH = ".div[3]/a[1]";
        private const string ADD_TASK_XPATH = ".div[3]/a[2]";

        private IWebElement teamCard;

        public TeamPageObject(IWebElement teamCard)
        {
            this.teamCard = teamCard;
        }

        public IWebElement NameTeamLink
        {
            get
            {
                return teamCard.FindElement(By.XPath(TEAM_NAME_XPATH));
            }
        }

        public IWebElement AmounterOfMembersText
        {
            get
            {
                return teamCard.FindElement(By.XPath(AMOUNT_OF_MEMBERS_XPATH));
            }
        }

        public IWebElement TeamDepartmentLink
        {
            get
            {
                return teamCard.FindElement(By.XPath(TEAM_DEPARTMENT_XPATH));
            }
        }

        public IWebElement AddTaskButton
        {
            get
            {
                return teamCard.FindElement(By.XPath(ADD_TASK_XPATH));
            }
        }
    }
}