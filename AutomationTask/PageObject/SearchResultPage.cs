using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutomationTask.PageObject
{
    class SearchResultPage
    {
        private IWebDriver driver;

        public SearchResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='search_form_input']")]
        public IWebElement searchResultInput;
    }
}
