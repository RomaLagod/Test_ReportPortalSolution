using OpenQA.Selenium;

namespace FluxDayAutomation.PageObjects
{
    public class LoginPageObject
    {
        private const string USER_EMAIL_ID = "user_email";
        private const string USER_PASSWORD_ID = "user_password";
        private const string LOGIN_CLASS = "btn-login";
        private const string REMEMBERME_CHECKBOX_ID = "user_remember_me";
        private const string REMEMBERME_LABEL_SELECTOR = "#new_user > div.remebrance > label";
        private const string REMEMBERME_INPUTBOX_HIDDEN_SELECTOR = "#new_user > div.remebrance > input[type='hidden']:nth-child(1)";

        private IWebDriver driver;

        public LoginPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement UserEmailTextBox
        {
            get
            {
                return driver.FindElement(By.Id(USER_EMAIL_ID));
            }
        }

        public IWebElement UserPasswordTextBox
        {
            get
            {
                return driver.FindElement(By.Id(USER_PASSWORD_ID));
            }
        }

        public IWebElement LoginButton
        {
            get
            {
                return driver.FindElement(By.ClassName(LOGIN_CLASS));
            }
        }

        public IWebElement RememberMeCheckBox
        {
            get
            {
                return driver.FindElement(By.Id(REMEMBERME_CHECKBOX_ID));
            }
        }

        public IWebElement RememberMeLabel
        {
            get
            {
                return driver.FindElement(By.CssSelector(REMEMBERME_LABEL_SELECTOR));
            }
        }

        public IWebElement RememberMeHiddenTextBox
        {
            get
            {
                return driver.FindElement(By.CssSelector(REMEMBERME_INPUTBOX_HIDDEN_SELECTOR));
            }
        }
    }
}
