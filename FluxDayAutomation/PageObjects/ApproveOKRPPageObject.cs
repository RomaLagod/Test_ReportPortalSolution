using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace FluxDayAutomation.PageObjects
{
    public class ApproveOKRPageObject
    {
        private const string APPROVE_BUTTON_CSS = "#pane3 > div > div.right.options > div > form > div > input.btn.btn-sec";
        private const string SETTINGS_BUTTON_CSS = "#pane3 > div > div.right.options > a";
        private const string SETTINGS_MENU_XPATH = "//*[@id=\"drop1\"]";
        private const int EXPLICIT_WAIT_SECONDS = 10;
        
        private IWebDriver driver;
        private WebDriverWait explicitWait = null;

        public ApproveOKRPageObject(IWebDriver driver)
        {
            this.driver = driver;
            explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(EXPLICIT_WAIT_SECONDS));
        }

        public IWebElement ApproveButton
        {
            get => driver.FindElement(By.CssSelector(APPROVE_BUTTON_CSS));
        }

        public IWebElement SettingsButton
        {
            get => explicitWait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.CssSelector(SETTINGS_BUTTON_CSS)))); 
        }

        public ApproveOKRMenu SettingsMenu
        {
            get => new ApproveOKRMenu(explicitWait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.XPath(SETTINGS_MENU_XPATH)))));
        }
    }
}
