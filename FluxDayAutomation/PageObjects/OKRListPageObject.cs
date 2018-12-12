using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace FluxDayAutomation.PageObjects
{
    // This class finds elements for the component of OKR list
    public class OKRListPageObject
    {
        private const string TITLE_CSS = "#pane2 > div.pane2-meta > div:nth-child(1) > div";
        private const string USERS_ID = "okr_user_id";
        private const string NEWOKR_XPATH = "//*[@id='pane2']/div[2]/a[1]";
        private const string OKRPANEL_CLASS = "pane2-content";
        private const string OKRCARD_XPATH = "//*[@id='pane2']/div[2]/a[not(contains(., 'New OKR'))]";
        private const string ACTUAL_USER_NAME_CSS = "#s2id_okr_user_id > a > span.select2-chosen";
        private const string USER_COMBOBOX_INPUT_CLASS = "select2-input";
        private const int EXPLICIT_WAIT_SECONDS = 10;

        private IWebDriver driver;
        private WebDriverWait explicitWait = null;

        public OKRListPageObject(IWebDriver driver)
        {
            this.driver = driver;
            explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(EXPLICIT_WAIT_SECONDS));

        }

        public IWebElement TitleLabel
        {
            get
            {
                return driver.FindElement(By.CssSelector(TITLE_CSS));
            }
        }

        public SelectElement UsersComboBox
        {
            get
            {
                return new SelectElement(driver.FindElement(By.Id(USERS_ID)));
            }
        }

        public IWebElement ActualUserName
        {
            get
            {
                return driver.FindElement(By.CssSelector(ACTUAL_USER_NAME_CSS));
            }
        }

        public IWebElement UserComboBoxInput
        {
            get
            {
                return explicitWait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.ClassName(USER_COMBOBOX_INPUT_CLASS))));
            }
        }

        public IWebElement NewOKRButton
        {
            get
            {
                return explicitWait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.XPath(NEWOKR_XPATH))));
            }
        }

        public IWebElement OKRPanel
        {
            get
            {
                return driver.FindElement(By.ClassName(OKRPANEL_CLASS));
            }
        }

        private IReadOnlyCollection<IWebElement> OKRCards
        {
            get
            {
                return driver.FindElements(By.XPath(OKRCARD_XPATH));
            }
        }

        public List<OKRPageObject> OKRsList
        {
            get
            {
                var OKRList = new List<OKRPageObject>();

                foreach (var OKR_Card in OKRCards)
                {
                    OKRList.Add(new OKRPageObject(OKR_Card));
                }

                return OKRList;
            }
        }
    }
}
