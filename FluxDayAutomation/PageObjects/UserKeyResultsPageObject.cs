using System.Collections.Generic;
using OpenQA.Selenium;

namespace FluxDayAutomation.PageObjects
{
    public class UserKeyResultsPageObject
    {
        private const string USER_NAME_CLASS = "title";
        private const string KEY_RESULT_CLASS = "input-set";

        private IWebElement parent;

        public UserKeyResultsPageObject(IWebElement parent)
        {
            this.parent = parent;   
        }

        public IWebElement UserName
        {
            get => parent.FindElement(By.ClassName(USER_NAME_CLASS));
        }

        public List<IWebElement> KeyResults
        {
            get
            {
                var result = new List<IWebElement>();
                var keyResultsList = parent.FindElements(By.ClassName(KEY_RESULT_CLASS));

                foreach (var element in keyResultsList)
                {
                    result.Add(element);
                }

                return result;
            }
        }
    }
}
