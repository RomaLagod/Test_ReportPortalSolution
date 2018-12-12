using System;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System.Drawing;

namespace FluxDayAutomation.Drivers
{
    static public class SelenoidDrivers 
    {
        private const bool ENABLE_VNC = true;
        private const int BROWSER_WIDTH = 1920;
        private const int BROWSER_HEIGHT = 1080;
        private const string URI = "http://13.80.22.30:4444/wd/hub";

        static public IWebDriver CreateDriver(string browser, string version)
        {
            var capabilities = new DesiredCapabilities(browser, version, new Platform(PlatformType.Any));
            capabilities.SetCapability("enableVNC", ENABLE_VNC);
            var driver = new RemoteWebDriver(new Uri(URI), capabilities);
            driver.Manage().Window.Size = new Size(BROWSER_WIDTH, BROWSER_HEIGHT);
            return driver;
        }
    }
}