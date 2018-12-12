using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FluxDayAutomation.PageObjects
{
    public class AddLogComponent
    {
        private const string ADD_LOG_CLASS = "a.btn.btn-sec.left";
        private const string CANCEL_CLASS = "cancel-btn";
        private const string SAVE_CLASS = "input.button.alert.right";
        private const string TASK_ID = "s2id_work_log_task_id";        
        private const string TIME_TAKEN_HOURS_ID = "s2id_work_log_hours";
        private const string TIME_TAKEN_MINS_ID = "s2id_work_log_mins";
        private const string DESCRIPTION_ID = "work_log_description";

        private IWebDriver driver;

        public AddLogComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement AddLogButton
        {
            get
            {
                return driver.FindElement(By.CssSelector(ADD_LOG_CLASS));
            }
        }

        public IWebElement CancelButton
        {
            get
            {
                return driver.FindElement(By.CssSelector(CANCEL_CLASS));
            }
        }

        public IWebElement SaveButton
        {
            get
            {
                return driver.FindElement(By.CssSelector(SAVE_CLASS));
            }
        }

        public SelectElement TaskComboBox
        {
            get
            {
                return new SelectElement(driver.FindElement(By.Id(TASK_ID)));
            }
        }

        public SelectElement TimeTakenHoursComboBox
        {
            get
            {
                return new SelectElement(driver.FindElement(By.Id(TIME_TAKEN_HOURS_ID)));
            }
        }

        public SelectElement TimeTakenMinsComboBox
        {
            get
            {
                return new SelectElement(driver.FindElement(By.Id(TIME_TAKEN_MINS_ID)));
            }
        }

        public IWebElement DescriptionTextBox
        {
            get
            {
                return driver.FindElement(By.Id(DESCRIPTION_ID));
            }
        }
    }
}