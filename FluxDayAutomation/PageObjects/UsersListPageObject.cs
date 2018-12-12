using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System;

namespace FluxDayAutomation.PageObjects
{
    public class UsersListPageObject
    {
        private const string ADDUSER_XPATH = "//*[@id='pane2']/div[2]/a";
        private const string PANE_CLASS = "pane2-content";
        private const string USER_CONTAINER_CLASS = "user-min";
        private const string USERS_PAGE_TITLE_CSS = "#pane2 > div.pane2-meta > div";
        private const int EXPLICIT_WAIT_SECONDS = 10;
        private WebDriverWait explicitWait = null;
        private IWebDriver driver;

        public UsersListPageObject(IWebDriver driver)
        {
            this.driver = driver;
            explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(EXPLICIT_WAIT_SECONDS));
        }

        public IWebElement UsersPageTitle
        {
            get
            {
                return explicitWait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.CssSelector(USERS_PAGE_TITLE_CSS))));
            }
        }

        public IWebElement AddUserButton
        {
            get
            { 
                return explicitWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(ADDUSER_XPATH)));
            }
        }

        public List<UserPageObject> UserList
        {
            get
            {
                var userListInstance = new List<UserPageObject>();
                var pane = explicitWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(PANE_CLASS)));
                var users = pane.FindElements(By.ClassName(USER_CONTAINER_CLASS));
                foreach (var user in users)
                {
                    var userPageObject = new UserPageObject(user);
                    userListInstance.Add(userPageObject);
                }
                return userListInstance;
            }
        }
    }    
}

