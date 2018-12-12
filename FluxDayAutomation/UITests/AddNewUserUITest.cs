using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using FluxDayAutomation.Drivers;
using FluxDayAutomation.PageObjects;

namespace FluxDayAutomation.UITests
{
    [Category("AddNewUser")]
    [TestFixture("firefox", "62.0")]
    [TestFixture("firefox", "63.0")]
    [TestFixture("chrome", "70.0")]
    [TestFixture("chrome", "71.0")]
    public class AddNewUserUITest
    {
        private const string FLUXDAY_URL = "https://app.fluxday.io/users/sign_in";
        private const string LOGIN_EMAIL = "admin@fluxday.io";
        private const string LOGIN_PASSWORD = "password";
        private string userName;
        private string userNickName;
        private string userEmail; 
        private string userCode;
        private const string USER_PASSWORD = "password";
        private IWebDriver driver = null;

        public AddNewUserUITest(string browser, string version)
        {
            this.driver = SelenoidDrivers.CreateDriver(browser, version);
        }
        
        [SetUp]
        public void Initializing()
        {   
            driver.Navigate().GoToUrl(FLUXDAY_URL);                                     
            LoginIntoSystem(LOGIN_EMAIL, LOGIN_PASSWORD);
            SetCredentials();
        }

        [TearDown]
        public void CleaneUp()
        {
            DeleteUser();
            driver.Quit();      
        }
        
        [Test]
        public void AddNewUserTest()
        {
            var sideBarMenu = new SideBarMenuPageObject(driver);     
            var addUserPage = new AddUserPageObject(driver);            
            var usersList = new UsersListPageObject(driver);            
            // navigate to Users Page
            sideBarMenu.UsersItem.Click();
            // add new user
            usersList.AddUserButton.Click();
            // fill all fields
            InputField(addUserPage.UserNameTextBox, userName);
            InputField(addUserPage.UserNickNameTextBox, userNickName);
            InputField(addUserPage.UserEmailTextBox, userEmail);
            InputField(addUserPage.UserEmployeeCodeTextBox, userCode);
            InputField(addUserPage.PasswordTextBox, USER_PASSWORD);
            InputField(addUserPage.PasswordConfirmationTextBox, USER_PASSWORD);
            addUserPage.SaveButton.Click();
            driver.Navigate().Refresh();       
            // result
            usersList = new UsersListPageObject(driver);
            Assert.IsTrue(usersList.UserList
                  .Select(x => x.NameLink.Text
                                .ToString())
                                .Where(x => x == userName)
                                .Count() > 0);
        }

        private void LoginIntoSystem(string email, string password)
        {
            var login = new LoginPageObject(driver);
            login.UserEmailTextBox.Click();
            login.UserEmailTextBox.Clear();
            login.UserEmailTextBox.SendKeys(email);
            login.UserPasswordTextBox.Click();
            login.UserPasswordTextBox.Clear();
            login.UserPasswordTextBox.SendKeys(password);
            login.LoginButton.Click();
        }

        private void DeleteUser()
        {
            driver.Navigate().Refresh();
            var usersListPO = new UsersListPageObject(driver);
            for (int i = 0; i < usersListPO.UserList.Count; i++)
            {
                var Name = usersListPO.UserList[i].NameLink.Text.ToString();
                if (Name == userName)
                {
                    usersListPO.UserList[i].SettingsLink.Click();
                    usersListPO.UserList[i].SettingsDeleteLink.Click();
                    driver.SwitchTo().Alert().Accept();
                }
            }
        }

        private void SetCredentials()
        {
            userName = RandomCredentials();
            userNickName = RandomCredentials();
            userEmail = RandomCredentials() + "@gmail.com";
            userCode = userNickName + "126";
        }

        private string RandomCredentials()
        {
            var random = new Random();
            var size = random.Next(10, 20);
            string build = "A";
            char tmp = 'a';
            int num;
            for (int i = 0; i <= size; ++i)
            {
                var symbol = random.Next(1, 25);
                num = 0;
                for (char ch = 'a'; ch <= 'z'; ++ch)
                {
                    if (num < symbol)
                    {
                        ++num;
                        continue;
                    }
                    else
                    {
                        tmp = ch;
                        break;
                    }
                }
                build += tmp;
            }
            return build;
        }
        
        private void InputField(IWebElement element, string text)
        {
            element.Click();
            element.Clear();
            element.SendKeys(text);
        }
    }
}