using OpenQA.Selenium;

namespace FluxDayAutomation.PageObjects
{
    // This class finds elements for the component of OKR card
    public class OKRPageObject
    {
        private const string CARDTITLE_CLASS = "title";
        private const string OKRDATERANGE_CLASS = "text";

        private IWebElement webElement;

        public OKRPageObject(IWebElement webElement)
        {
            this.webElement = webElement;
        }

        public IWebElement OKRCardLink
        {
            get
            {
                return this.webElement;
            }
        }

        public IWebElement TitleLabel
        {
            get
            {
                return webElement.FindElement(By.ClassName(CARDTITLE_CLASS));
            }
        }

        public IWebElement OKRDateRangeLabel
        {
            get
            {
                return webElement.FindElement(By.ClassName(OKRDATERANGE_CLASS));
            }
        }
    }
}
