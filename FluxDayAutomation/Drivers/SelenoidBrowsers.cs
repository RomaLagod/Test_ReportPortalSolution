using System;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;
using System.Drawing;

namespace FluxDayAutomation.Drivers
{
    public class SelenoidBrowsers
    {
        private const bool ENABLE_VNC = true;
        private const int BROWSER_WIDTH = 1920;
        private const int BROWSER_HEIGHT = 1080;
        private const string URI = "http://172.17.0.1:4444/wd/hub";
        private readonly string[] drivers =  {"chrome", "firefox", "opera"};
        private readonly string[] firefoxVersions = {"59.0", "60.0", "61.0", "62.0", "63.0"};
        private readonly string[] chromeVersions = {"66.0", "67.0", "68.0", "69.0", "70.0"};
        private readonly string[] operaVersions = {"52.0", "53.0", "54.0", "55.0", "56.0"};

        private IWebDriver DriverCreator(string browser, string version)
        {
            var capabilities = new DesiredCapabilities(browser, version, new Platform(PlatformType.Any));
            capabilities.SetCapability("enableVNC", ENABLE_VNC);
            var driver = new RemoteWebDriver(new Uri(URI), capabilities);
            driver.Manage().Window.Size = new Size(BROWSER_WIDTH, BROWSER_HEIGHT);
            return driver;
        }

        public IWebDriver Firefox59
        {
            get
            {
                return DriverCreator(drivers[1], firefoxVersions[0]);
            }
        }

        public IWebDriver Firefox60
        {
            get
            {
                return DriverCreator(drivers[1], firefoxVersions[1]);
            }
        }

        public IWebDriver Firefox61
        {
            get
            {
                return DriverCreator(drivers[1], firefoxVersions[2]);
            }
        }

        public IWebDriver Firefox62
        {
            get
            {
               return DriverCreator(drivers[1], firefoxVersions[3]);
            }
        }

        public IWebDriver Firefox63
        {
            get
            {
                return DriverCreator(drivers[1], firefoxVersions[4]);
            }
        }

        public IWebDriver Chrome66
        {
            get
            {
                return DriverCreator(drivers[0], chromeVersions[0]);
            }
        }

        public IWebDriver Chrome67
        {
            get
            {
                return DriverCreator(drivers[0], chromeVersions[1]);
            }
        }

        public IWebDriver Chrome68
        {
            get
            {
                return DriverCreator(drivers[0], chromeVersions[2]);
            }
        }

        public IWebDriver Chrome69
        {
            get
            {
                return DriverCreator(drivers[0], chromeVersions[3]);
            }
        }

        public IWebDriver Chrome70
        {
            get
            {
                return DriverCreator(drivers[0], chromeVersions[4]);
            }
        }

        public IWebDriver Opera52
        {
            get
            {
                return DriverCreator(drivers[2], operaVersions[0]);
            }
        }

        public IWebDriver Opera53
        {
            get
            {
                return DriverCreator(drivers[2], operaVersions[1]);
            }
        }

        public IWebDriver Opera54
        {
            get
            {
                return DriverCreator(drivers[2], operaVersions[2]);
            }
        }

        public IWebDriver Opera55
        {
            get
            {
                return DriverCreator(drivers[2], operaVersions[3]);
            }
        }

        public IWebDriver Opera56
        {
            get
            {
                return DriverCreator(drivers[2], operaVersions[4]);
            }
        }
    }         
}