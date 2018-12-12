using System.Collections.Generic;
using OpenQA.Selenium;

namespace FluxDayAutomation.PageObjects
{
    /// <summary>
    /// this class finds the WebElements of the pane3 ("https://app.fluxday.io/users/FT1/okrs/new#pane3")
    /// and contains methods that represents these WebElements
    /// </summary>
    public class SetOKRPageObject
    {
        /// <summary>
        /// constants that simplify using variables for the method driver.FindElement
        /// </summary>>
        private const string CANCEL_BUTTON_XPATH = "//form/div[3]/div[2]/a";
        private const string SAVE_BUTTON_XPATH = "//form/div[3]/div[2]/input";
        private const string OKR_NAME_FIELD_ID = "okr_name";
        private const string START_DATE_DATEPICKER_ID = "okr_start_date";
        private const string END_DATE_DATEPICKER_ID = "okr_end_date";
        private const string START_DATE_LABEL_XPATH = "//form/div[2]/div[2]/div[1]/label";
        private const string END_DATE_LABEL_XPATH = "//form/div[2]/div[3]/div[1]/label";
        private const string TITLE_LABEL_XPATH = "//form/div[3]/div[1]";
        private const string ADD_OBJECTIVE_BUTTON_CSS = "#objectives > div.links.okr-field-add > a"; 
        private const string OBJECTIVE_LIST_CLASS = "objective-set";

        private IWebDriver driver;

        public SetOKRPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement CancelButton
        {
            get
            {
                return driver.FindElement(By.XPath(CANCEL_BUTTON_XPATH));
            }
        }

        public IWebElement SaveButton
        {
            get
            {
                return driver.FindElement(By.XPath(SAVE_BUTTON_XPATH));
            }
        }

        public IWebElement OKRNameField
        {
            get
            {
                return driver.FindElement(By.Id(OKR_NAME_FIELD_ID));
            }
        }

        public IWebElement StartDateDatePicker
        {
            get
            {
                return driver.FindElement(By.Id(START_DATE_DATEPICKER_ID));
            }
        }

        public IWebElement EndDateDatepicker
        {
            get
            {
                return driver.FindElement(By.Id(END_DATE_DATEPICKER_ID));
            }
        }

        public IWebElement StartDateLabel
        {
            get
            {
                return driver.FindElement(By.XPath(START_DATE_LABEL_XPATH));
            }
        }

        public IWebElement EndDateLabel
        {
            get
            {
                return driver.FindElement(By.XPath(END_DATE_LABEL_XPATH));
            }
        }

        public IWebElement TitleLabel
        {
            get
            {
                return driver.FindElement(By.XPath(TITLE_LABEL_XPATH));
            }
        }

        public IWebElement AddObjectiveButton
        {
            get
            {
                return driver.FindElement(By.CssSelector(ADD_OBJECTIVE_BUTTON_CSS));
            }
        }

        public List<ObjectivePageObject> ObjectivesList
        {
            get
            {
                var elements = driver.FindElements(By.ClassName(OBJECTIVE_LIST_CLASS));
                var objectiveList = new List<ObjectivePageObject>();

                foreach (var element in elements)
                {
                    objectiveList.Add(new ObjectivePageObject(element));
                }

                return objectiveList;
            }
        }
    }
}