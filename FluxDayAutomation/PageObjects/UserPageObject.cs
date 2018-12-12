using OpenQA.Selenium;

namespace FluxDayAutomation.PageObjects
{
    public class UserPageObject
    {
        private const string PICTURE_LINK_PARENT_CLASS = "left";
        private const string PICTURE_LINK_TAG = "a";
        private const string NAME_LINK_CLASS = "name";
        private const string NICKNAME_LINK_CLASS = "nickname";
        private const string OKR_LINK_PARENT_CLASS = "right";
        private const string OKR_LINK_TAG = "a";
        private const string SETTINGS_XPATH = "//*[@id='pane3']/div/div[1]/div[2]/a"; 
        private const string SETTINGS_EDIT_CSS = "#drop1 > li:nth-child(1) > a";
        private const string SETTINGS_DELETE_XPATH = "//*[@id='drop1']/li[2]/a";

        private IWebElement user;

        public UserPageObject(IWebElement user)
        {
            this.user = user;
        }

        public IWebElement PictureLink
        {
            get
            {
                var pictureLinkParent = user.FindElement(By.ClassName(PICTURE_LINK_PARENT_CLASS));
                return pictureLinkParent.FindElement(By.TagName(PICTURE_LINK_TAG));
            }
        }

        public IWebElement NameLink
        {
            get
            {
                return user.FindElement(By.ClassName(NAME_LINK_CLASS));
            }
        }

        public IWebElement NickNameLink
        {
            get
            {
                return user.FindElement(By.ClassName(NICKNAME_LINK_CLASS));
            }
        }

        public IWebElement SettingsLink
        {
            get
            {
                return user.FindElement(By.XPath(SETTINGS_XPATH));
            }
        }

        public IWebElement SettingsDeleteLink
        {
            get
            {
                return user.FindElement(By.XPath(SETTINGS_DELETE_XPATH));
            }
        }

        public IWebElement SettingsEditLink
        {
            get
            {
                return user.FindElement(By.ClassName(SETTINGS_EDIT_CSS));
            }
        }

        public IWebElement OkrLink
        {
            get
            {
                var okrLinkParent = user.FindElement(By.ClassName(OKR_LINK_PARENT_CLASS));
                return okrLinkParent.FindElement(By.TagName(OKR_LINK_TAG));
            }
        }
    }
}
