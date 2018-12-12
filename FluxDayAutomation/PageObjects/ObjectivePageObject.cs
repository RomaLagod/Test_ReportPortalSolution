using OpenQA.Selenium;
using System.Collections.Generic;

namespace FluxDayAutomation.PageObjects
{
    /// <summary>
    /// this class finds the WebElements of the form "objective" (class="nested-fields" parent element id="objectives")
    /// </summary>
    public class ObjectivePageObject 
    {
        private const string OBJECTIVE_FIELD_CSS = "#objectives > div:nth-child(1) > div > div.form-row > div.small-11.columns> :first-child";
        private const string REMOVE_OBJECTIVE_LINK_CSS = ".objective-set > div:nth-child(1) > div:nth-child(2) > div:nth-child(1) > a:nth-child(2)";
        private const string ADD_KEY_RESULT_BUTTON_CSS = "#key_results > div.links.okr-field-add > a";
        private const string KEY_RESULT_LIST_CSS = "#key_results .form-row";

        private IWebElement element;
        
        public ObjectivePageObject(IWebElement element)
        {
             this.element = element;
        }
        
        public IWebElement ObjectiveNameField
        {
            get
            {
                return element.FindElement(By.CssSelector(OBJECTIVE_FIELD_CSS));
            }
        }

        public IWebElement AddKeyResultButton
        {
            get
            {
                return element.FindElement(By.CssSelector(ADD_KEY_RESULT_BUTTON_CSS));
            }
        }

        public IWebElement RemoveObjectLink
        {
            get
            {
                return element.FindElement(By.CssSelector(REMOVE_OBJECTIVE_LINK_CSS));
            }
        }
 
        public List<KeyResultPageObject> KeyResultsList
        {             
             get
             {
                var keyResultList = element.FindElements(By.CssSelector(KEY_RESULT_LIST_CSS));

                var keyResult = new List<KeyResultPageObject>();

                 foreach (var keyResultElement in keyResultList)
                 {
                    keyResult.Add(new KeyResultPageObject(keyResultElement));
                 }

                 return keyResult;
             }
        }
    }
}