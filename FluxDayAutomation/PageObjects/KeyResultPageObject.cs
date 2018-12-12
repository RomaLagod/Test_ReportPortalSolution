using OpenQA.Selenium;

namespace FluxDayAutomation.PageObjects
{
    /// <summary>
    /// this class finds the WebElements of the division (class="nested-fields" parent element id="key_results")
    /// </summary>
    public class KeyResultPageObject
    {
        private const string REMOVE_KEY_RESULT_LINK_XPATH= "div[2]/div/a";
        private const string KEY_RESULT_FIELD_XPATH = "div[1]/input";

        private IWebElement element;

        public KeyResultPageObject(IWebElement element)
        {
             this.element = element;
        }
      
        public IWebElement RemoveKeyResultLink
        {
            get
            {
                return element.FindElement(By.XPath(REMOVE_KEY_RESULT_LINK_XPATH));
            }
        }

        public IWebElement KeyResultField
        {
            get
            {
                return element.FindElement(By.XPath(KEY_RESULT_FIELD_XPATH));
            }
        }
    }
}