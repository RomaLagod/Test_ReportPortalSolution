using OpenQA.Selenium;

namespace FluxDayAutomation.PageObjects
{
    public class DeleteTaskPageObject
    {
        public const string SETTINGS_ICON_CSS = "#pane3 > div.pane3-content > div > div.task-details > div.bc-div > div > a.dropdown.right > div";
        public const string DROPDOWN_LIST_XPATH = "//*[@id=\"pane3\"]/div[2]/div/div[1]/div[1]/div";

        private IWebDriver driver;

        public DeleteTaskPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SettingsIcon
        {
            get
            {
                return driver.FindElement(By.CssSelector(SETTINGS_ICON_CSS));
            }
        }

        public DeleteTaskMenuPageObject DropdownList
        {
            get
            {
                return new DeleteTaskMenuPageObject(driver.FindElement(By.XPath(DROPDOWN_LIST_XPATH)));
            }
        }
    }
}