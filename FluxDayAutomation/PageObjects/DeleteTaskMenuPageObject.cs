using OpenQA.Selenium;

namespace FluxDayAutomation.PageObjects
{
    public class DeleteTaskMenuPageObject
    {
        private const string EDIT_ITEM_XPATH = "ul/li[1]/a";
        private const string DELETE_ITEM_XPATH = "ul/li[2]/a";

        private IWebElement element;

        public DeleteTaskMenuPageObject(IWebElement element)
        {
            this.element = element;
        }

        public IWebElement EditItem
        {
            get
            {
                return element.FindElement(By.XPath(EDIT_ITEM_XPATH));
            }
        }
        
        public IWebElement DeleteItem
        {
            get
            {
                return element.FindElement(By.XPath(DELETE_ITEM_XPATH));
            }
        }
    }
}