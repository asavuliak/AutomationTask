using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTask.PageObject
{
    class MainPage
    {
        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div/h1[@class='logo']")]
        public IWebElement Logo;

        [FindsBy(How = How.XPath, Using = "//h2[@id='technologies']")]
        public IWebElement technologies;

        [FindsBy(How = How.XPath, Using = "//ul[@class='theme']/li/a[contains(@title, 'Popular links to W3C technology information')]")]
        public IWebElement W3CAToZMap;

        [FindsBy(How = How.XPath, Using = "//div[@id='search-form']/input")]
        public IWebElement searchForm;

        [FindsBy(How = How.XPath, Using = "//div[@class='unit size1on2 lastUnit']/ul/li[1]/a")]
        public IWebElement selectFirstElement;

        [FindsBy(How = How.XPath, Using = "//div[@class='unit size1on2 lastUnit']/ul/li[last()]/a")]
        public IWebElement selectLastElement;

        [FindsBy(How = How.XPath, Using = "//button[@id='search-submit']")]
        public IWebElement searchButton;

        public ICollection<IWebElement> findElementsList()
        {
            return driver.FindElements(By.XPath("//div[@class='unit size1on2 lastUnit']/ul/li"));
        }
    }
}
