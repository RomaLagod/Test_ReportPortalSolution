using FluxDayAutomation.PageObjects;
using FluxDayAutomation.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace FluxDayAutomation.UITests
{
    [Category("Login")]
    [TestFixture(MANAGER_EMAIL, MANAGER_PASSWORD, MANAGER_USER_NAME, "firefox", "62.0")]
    [TestFixture(MANAGER_EMAIL, MANAGER_PASSWORD, MANAGER_USER_NAME, "firefox", "63.0")]
    [TestFixture(MANAGER_EMAIL, MANAGER_PASSWORD, MANAGER_USER_NAME, "chrome", "70.0")]
    [TestFixture(MANAGER_EMAIL, MANAGER_PASSWORD, MANAGER_USER_NAME, "chrome", "71.0")]
    public class LoginUITest
    {
        private IWebDriver driver = null;
        private const string APPLICATION_URL = "https://app.fluxday.io";
        private const string LOGOUT_TEXT = "Logout";
        private const string MANAGER_USER_NAME = "Admin User";
        private const string MANAGER_EMAIL = "admin@fluxday.io";
        private const string MANAGER_PASSWORD = "password";
        private const string EMPLOYEE_USER_NAME = "Employee 1";
        private const string EMPLOYEE_EMAIL = "emp1@fluxday.io";
        private const string EMPLOYEE_PASSWORD = "password";
        private string email = null;
        private string password = null;
        private string userName = null;


        public LoginUITest(string email, string password, string userName, string browser, string version)
        {
            this.email = email;
            this.password = password;
            this.userName = userName;
            this.driver = SelenoidDrivers.CreateDriver(browser, version);
        }
        
        [SetUp]
        public void Initialization()
        {
            driver.Navigate().GoToUrl(APPLICATION_URL);          
        }

        [TearDown]
        public void AfterAllMethods()
        {
            var sideBarMenu = new SideBarMenuPageObject(driver);

            sideBarMenu.LogoutItem.Click();
            driver.Quit();
        }

        [Test]
        public void LoginTest()
        {
            var login = new LoginPageObject(driver);
            var sideBarMenu = new SideBarMenuPageObject(driver);

            // user email
            login.UserEmailTextBox.Click();
            login.UserEmailTextBox.Clear();
            login.UserEmailTextBox.SendKeys(email);

            // user password
            login.UserPasswordTextBox.Click();
            login.UserPasswordTextBox.Clear();
            login.UserPasswordTextBox.SendKeys(password);

            // press button
            login.LoginButton.Click();

            // check the expected result
            Assert.AreEqual(userName, sideBarMenu.UserNameItem.Text);
            Assert.AreEqual(LOGOUT_TEXT, sideBarMenu.LogoutItem.Text);
        }
    }
}