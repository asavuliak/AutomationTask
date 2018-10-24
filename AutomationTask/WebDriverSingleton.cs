using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

namespace AutomationTask
{
    public class WebDriverSingleton
    {
        public static IWebDriver driver;
        private WebDriverSingleton()
        {

        }

        public static IWebDriver getInstance()
        {

            if (driver == null)
            {
                driver = new ChromeDriver();
            }
            return driver;
        }
    }
}
