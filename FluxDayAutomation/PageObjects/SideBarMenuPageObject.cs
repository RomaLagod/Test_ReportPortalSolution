using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FluxDayAutomation.PageObjects
{
    public class SideBarMenuPageObject
    {
        private const string DASHBOARD_CSS = "body > div.row.ep-tracker > div.large-2.columns.pane1.show-for-large-up > ul.side-nav.sidebar-links.top-set > li:nth-child(1) > a > span";        
        private const string MY_TASKS_CSS = "body > div.row.ep-tracker > div.large-2.columns.pane1.show-for-large-up > ul.side-nav.sidebar-links.top-set > li:nth-child(2) > a";        
        private const string DEPARTMENTS_CSS = "body > div.row.ep-tracker > div.large-2.columns.pane1.show-for-large-up > ul.side-nav.sidebar-links.top-set > li:nth-child(3) > a";        
        private const string TEAM_CSS = "body > div.row.ep-tracker > div.large-2.columns.pane1.show-for-large-up > ul.side-nav.sidebar-links.top-set > li:nth-child(4) > a";        
        private const string USERS_CSS = "body > div.row.ep-tracker > div.large-2.columns.pane1.show-for-large-up > ul.side-nav.sidebar-links.top-set > li:nth-child(5) > a";        
        private const string OKR_CSS = "body > div.row.ep-tracker > div.large-2.columns.pane1.show-for-large-up > ul.side-nav.sidebar-links.top-set > li:nth-child(6) > a";        
        private const string REPORTS_CSS = "body > div.row.ep-tracker > div.large-2.columns.pane1.show-for-large-up > ul.side-nav.sidebar-links.top-set > li:nth-child(7) > a";        
        private const string OAUTH_APPLICATIONS_CSS = "body > div.row.ep-tracker > div.large-2.columns.pane1.show-for-large-up > ul.side-nav.sidebar-links.top-set > li:nth-child(8) > a";        
        private const string USER_NAME_CSS = "body > div.row.ep-tracker > div.large-2.columns.pane1.show-for-large-up > ul.user-links.side-nav.sidebar-links > li:nth-child(1) > a";        
        private const string LOGOUT_CSS = "body > div.row.ep-tracker > div.large-2.columns.pane1.show-for-large-up > ul.user-links.side-nav.sidebar-links > li:nth-child(2) > a";
        private const int EXPLICIT_WAIT_SECONDS = 10;
        private WebDriverWait explicitWait = null;
        

        private IWebDriver driver;
        
        public SideBarMenuPageObject(IWebDriver driver)
        {
            this.driver = driver;
            explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(EXPLICIT_WAIT_SECONDS));
        }

        public IWebElement MyTasks
        {
            get
            {
                return explicitWait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.CssSelector(MY_TASKS_CSS))));
            }
        }

        public IWebElement DepartmentsItem
        {
            get
            {
                return explicitWait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.CssSelector(DEPARTMENTS_CSS))));
            }
        }

        public IWebElement TeamItem
        {
            get
            {
                return explicitWait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.CssSelector(TEAM_CSS))));
            }
        }

        public IWebElement UsersItem
        {
            get
            {
                return explicitWait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.CssSelector(USERS_CSS))));
            }
        }

        public IWebElement OKRItem
        {
            get
            {
                return explicitWait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.CssSelector(OKR_CSS))));
            }
        }

        public IWebElement ReportsItem
        {
            get
            {
                return explicitWait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.CssSelector(REPORTS_CSS))));
            }
        }

        public IWebElement OauthApplicationItem
        {
            get
            {
                return explicitWait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.CssSelector(OAUTH_APPLICATIONS_CSS))));
            }
        }

        public IWebElement UserNameItem
        {
            get
            {
                return explicitWait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.CssSelector(USER_NAME_CSS))));
            }
        }

        public IWebElement LogoutItem
        {
            get
            {
                return explicitWait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.CssSelector(LOGOUT_CSS))));
            }
        }
    }
}