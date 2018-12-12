using OpenQA.Selenium;

namespace FluxDayAutomation.PageObjects
{
    public class TopPanelPageObject
    {
        private IWebDriver driver;

        private const string FLUXDAY_LABEL_CSS = "body > div.fixed > nav > ul > li.name > h1 > a";
        private const string PLUS_TASK_BUTTON_CSS = "body > div.fixed > nav > section > ul.right > li > a";

        public TopPanelPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FluxdayLabel
        {
            get => driver.FindElement(By.CssSelector(FLUXDAY_LABEL_CSS));
        }

        public IWebElement PlusTaskButton
        {
            get => driver.FindElement(By.CssSelector(PLUS_TASK_BUTTON_CSS));
        }
    }
}
