using System.Collections.Generic;
using OpenQA.Selenium;

namespace FluxDayAutomation.PageObjects
{
    public class TeamsListPageObjects 
    {
        private const string TITLE_TEAM_CLASS = "title";
        private const string TEAM_CARD_XPATH = "//*[@id='pane2']/div[2]/div";

        private IWebDriver driver;

        public TeamsListPageObjects(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement TitleTeamText
        {
            get
            {
                return driver.FindElement(By.ClassName(TITLE_TEAM_CLASS));
            }
        }
       
        public List<TeamPageObject> TeamsList
        {
            get
            {
                var teamsList = new List<TeamPageObject>();
                var teamCards = driver.FindElements(By.XPath(TEAM_CARD_XPATH));
               
                foreach (var teamCard in teamCards)
                {
                    teamsList.Add(new TeamPageObject(teamCard));
                }

                return teamsList;
            }        
        }
    }
}