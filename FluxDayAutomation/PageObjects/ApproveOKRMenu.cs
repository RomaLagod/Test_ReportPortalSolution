using OpenQA.Selenium;

namespace FluxDayAutomation.PageObjects
{
    public class ApproveOKRMenu
    {
        private const string EDIT_MENU_ITEM_XPATH = "./li[1]/a"; 
        private const string DELETE_MENU_ITEM_XPATH = "./li[2]/a";

        private IWebElement parent;
        
        public ApproveOKRMenu(IWebElement parent)
        {
            this.parent = parent;
        }

        public IWebElement EditMenuItem
        {
            get => parent.FindElement(By.XPath(EDIT_MENU_ITEM_XPATH));
        }

        public IWebElement DeleteMenuItem
        {
            get => parent.FindElement(By.XPath(DELETE_MENU_ITEM_XPATH));
        }
    }
}
