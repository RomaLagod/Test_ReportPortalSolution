using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using FluxDayAutomation.PageObjects;
using FluxDayAutomation.Drivers;

namespace FluxDayAutomation.UITests
{
    [TestFixture]
    [Category("DeleteOKR")]
    [TestFixture("firefox", "62.0")]
    [TestFixture("firefox", "63.0")]
    [TestFixture("chrome", "70.0")]
    [TestFixture("chrome", "71.0")]

    public class DeleteOKRTest
    {
        private const string APPLICATION_URL = "https://app.fluxday.io";
        private const int IMPLICIT_WAIT_TIMEOUT = 10;
        private const string MANAGER_USER_NAME = "Admin User";
        private const string MANAGER_EMAIL = "admin@fluxday.io";
        private const string MANAGER_PASSWORD = "password";
        private const string TEST_OKR_NAME = "Delete OKR Test: Temporary OKR";
        private const string TEST_OKR_OBJECTIVE_TEXT = "Test Objective";
        private const string TEST_OKR_KEYRESULT_TEXT = "Test Key Result";
        private const string ASSERT_TEXT = "Assert: Found OKR, created in this test. Please delete it manually.";

        private IWebDriver driver;
        private OKRListPageObject okrListPageObject;

        public DeleteOKRTest(string browser, string version)
        {
            this.driver = SelenoidDrivers.CreateDriver(browser, version);
        }

        [SetUp]
        public void Initialization()
        {
            // Driver configuring and navigating to Application
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(IMPLICIT_WAIT_TIMEOUT);
            driver.Navigate().GoToUrl(APPLICATION_URL);

            // Pre-condition: Logging in as manager
            var loginPageObject = new LoginPageObject(driver);
            SetInputField(loginPageObject.UserEmailTextBox, MANAGER_EMAIL);
            SetInputField(loginPageObject.UserPasswordTextBox, MANAGER_PASSWORD);
            loginPageObject.LoginButton.Click();

            // Navigating to OKRs list page
            var sidebarMenuPageObject = new SideBarMenuPageObject(driver);
            sidebarMenuPageObject.OKRItem.Click();

            // Pre-condition: creating temporary OKR for Admin User
            okrListPageObject = new OKRListPageObject(driver);
            okrListPageObject.UsersComboBox.SelectByText(MANAGER_USER_NAME);
            okrListPageObject.NewOKRButton.Click();

            var newOKRPageObject = new SetOKRPageObject(driver);
            SetInputField(newOKRPageObject.OKRNameField, TEST_OKR_NAME);
            SetInputField(newOKRPageObject.ObjectivesList[0].ObjectiveNameField, TEST_OKR_OBJECTIVE_TEXT);
            newOKRPageObject.ObjectivesList[0].KeyResultsList[0].RemoveKeyResultLink.Click();  // Removing unnecessary Key Result
            SetInputField(newOKRPageObject.ObjectivesList[0].KeyResultsList[0].KeyResultField, TEST_OKR_KEYRESULT_TEXT);
            newOKRPageObject.SaveButton.Click();
        }

        [Test]
        public void DeleteOKRTestCase()
        {
            okrListPageObject.UsersComboBox.SelectByText(MANAGER_USER_NAME);

            var approveOKRPageObject = new ApproveOKRPageObject(driver);
            var okrList = okrListPageObject.OKRsList;

            for (int i = 0; i < okrList.Count; i++)
            {
                // Reinitializing variables every iteration to avoid StaleElementReffereceException
                var okrTitleLabel = okrList[i].TitleLabel;
                var okrTitle = okrTitleLabel.Text;

                if (okrTitle == TEST_OKR_NAME)
                {
                    okrTitleLabel.Click();
                    approveOKRPageObject.SettingsButton.Click();
                    approveOKRPageObject.SettingsMenu.DeleteMenuItem.Click();
                    driver.SwitchTo().Alert().Accept();

                    // Reinitializing OKR List and moving to previous iteration to avoid StaleElementRefferenceException
                    okrList = okrListPageObject.OKRsList;
                    i--;
                }
            }

            // Checking results
            Assert.IsTrue(okrListPageObject.OKRsList.All(i => !i.TitleLabel.Text.Equals(TEST_OKR_NAME)), ASSERT_TEXT);
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }

        private void SetInputField(IWebElement field, string text)
        {
            field.Clear();
            field.SendKeys(text);
        }
    }
}