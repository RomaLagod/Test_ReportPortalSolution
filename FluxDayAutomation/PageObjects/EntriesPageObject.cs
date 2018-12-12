using OpenQA.Selenium;

namespace FluxDayAutomation.PageObjects
{
    public class EntriesPageObject
    {
        private const string WEEK_BUTTON_XPATH = "//*[@id='pane2']/div[1]/dl/dd[1]/a";        
        private const string MONTH_BUTTON_XPATH = "//*[@id='pane2']/div[1]/dl/dd[2]/a";        
        private const string ADDLOG_BUTTON_XPATH = "//*[@id='week']/div/div[1]/div[1]/a[2]";        
        private const string PREVIOUSWEEK_BUTTON_XPATH = "//*[@id='week']/div/div[2]/a[1]/div";        
        private const string NEXTWEEK_BUTTON_XPATH = "//*[@id='week']/div/div[2]/a[2]/div";        
        private const string PREVIOUSMONTH_BUTTON_XPATH = "//*[@id='month']/div[1]/div/div/div[1]/table/thead/tr[1]/th[1]/i";        
        private const string NEXTMONTH_BUTTON_XPATH = "//*[@id='month']/div[1]/div/div/div[1]/table/thead/tr[1]/th[3]/i";        
        private const string SWITCHDATE_LABEL_XPATH = "//*[@id='month']/div[1]/div/div/div[1]/table/thead/tr[1]/th[2]";

        private IWebDriver driver;

        public EntriesPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement WeekEntriesButton
        {
            get 
            {
                return driver.FindElement(By.XPath(WEEK_BUTTON_XPATH));
            }
        }

        public IWebElement MonthEntriesButton
        {
            get 
            {
                return driver.FindElement(By.XPath(MONTH_BUTTON_XPATH));
            }
        }

        public IWebElement AddLogButton
        {
            get 
            {
                return driver.FindElement(By.XPath(ADDLOG_BUTTON_XPATH));
            }
        }

        public IWebElement PreviousWeekButton
        {
            get 
            {
                return driver.FindElement(By.XPath(PREVIOUSWEEK_BUTTON_XPATH));
            }
        }

        public IWebElement NextWeekButton
        {
            get 
            {
                return driver.FindElement(By.XPath(NEXTWEEK_BUTTON_XPATH));
            }
        }

        public IWebElement PreviousMonthButton
        {
            get 
            {
                return driver.FindElement(By.XPath(PREVIOUSMONTH_BUTTON_XPATH));
            }
        }

        public IWebElement NextMonthButton
        {
            get 
            {
                return driver.FindElement(By.XPath(NEXTMONTH_BUTTON_XPATH));
            }
        }

        public IWebElement SwitchDateLabel
        {
            get 
            {
                return driver.FindElement(By.XPath(SWITCHDATE_LABEL_XPATH));
            }
        }
    }
}