using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FluxDayAutomation.PageObjects
{
    // This class finds elements for the component of adding a new user
    public class AddUserPageObject
    {
        private const string TITLE_CSS = "#new_user > div.small-12.columns.form-action-up > div.title";
        private const string USER_NAME_ID = "user_name";
        private const string USER_NICKNAME_ID = "user_nickname";
        private const string USER_IMAGE_ID = "user_image";
        private const string USER_EMAIL_ID = "user_email";
        private const string USER_EMPLOYEE_CODE_ID = "user_employee_code";
        private const string ROLE_ID = "user_role";
        private const string USER_PASSWORD_ID = "user_password";
        private const string USER_PASSWORD_CONFIRMATION_ID = "user_password_confirmation";
        private const string MANAGERS_ID = "user_manager_ids";
        private const string CANCEL_CLASS = ".btn";
        private const string SAVE_CLASS = ".button";

        private IWebDriver driver;

        public AddUserPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement TitleLabel
        {
            get
            {
                return driver.FindElement(By.CssSelector(TITLE_CSS));
            }
        }

        public IWebElement UserNameTextBox
        {
            get
            {
                return driver.FindElement(By.Id(USER_NAME_ID));
            }
        }

        public IWebElement UserNickNameTextBox
        {
            get
            {
                return driver.FindElement(By.Id(USER_NICKNAME_ID));
            }
        }

        public IWebElement UserImageButton
        {
            get
            {
                return driver.FindElement(By.Id(USER_IMAGE_ID));
            }
        }

        public IWebElement UserEmailTextBox
        {
            get
            {
                return driver.FindElement(By.Id(USER_EMAIL_ID));
            }
        }

        public IWebElement UserEmployeeCodeTextBox
        {
            get
            {
                return driver.FindElement(By.Id(USER_EMPLOYEE_CODE_ID));
            }
        }

        public SelectElement RoleComboBox
        {
            get
            {
                return new SelectElement(driver.FindElement(By.Id(ROLE_ID)));
            }
        }

        public IWebElement PasswordTextBox
        {
            get
            {
                return driver.FindElement(By.Id(USER_PASSWORD_ID));
            }
        }

        public IWebElement PasswordConfirmationTextBox
        {
            get
            {
                return driver.FindElement(By.Id(USER_PASSWORD_CONFIRMATION_ID));
            }
        }

        public SelectElement ManagersComboBox
        {
            get
            {
                return new SelectElement(driver.FindElement(By.Id(MANAGERS_ID)));
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
    }
}