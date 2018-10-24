using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationTask.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace AutomationTask
{
    [Binding]
    public class StepDefinition
    {
        private IWebDriver driver;

        [Before]
        public void before()
        {
            driver = WebDriverSingleton.getInstance();
            driver.Manage().Window.Maximize();
        }

        [Given(@"end user navigates to '(.*)' and click to '(.*)' link")]
        public void GivenEndUserNavigatesToAndClickToLink(string url, string link)
        {
            MainPage locator = new MainPage(driver);
            var expectedElements = locator.technologies;

            goToPage(url);
            locator.W3CAToZMap.Click();

            waitUntil(15, expectedElements);

        }

        [Then(@"store a path of the link in the variable")]
        public void ThenStoreAPathOfTheLinkInTheVariable()
        {
            MainPage locator = new MainPage(driver);
            var variable = string.Empty;

            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);

            ICollection<IWebElement> findElementsList = locator.findElementsList();
            //waitUntil(15, locator.selectFirstElement);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            var count = findElementsList.Count();
            if (count > 50)
            {
                variable = locator.selectFirstElement.GetAttribute("href");
            }

            if (count < 50)
            {
                variable = locator.selectLastElement.GetAttribute("href");
            }

            ScenarioContext.Current.Set(variable, "variable");
        }

        [Then(@"search result by the last part of URL from stored variable")]
        public void ThenSearchResultByTheLastPartOfURLFromStoredVariable()
        {
            MainPage locator = new MainPage(driver);
            SearchResultPage searchResult = new SearchResultPage(driver);
            var variable = ScenarioContext.Current.Get<string>("variable");

            locator.Logo.Click();

            string lastPart = variable.Split('/').Last();
            if (lastPart == String.Empty)
            {
                var c = variable.LastIndexOf("/");
                variable = variable.Remove(c, 1);
                lastPart = variable.Split('/').Last();
            }

            locator.searchForm.SendKeys(lastPart);

            locator.searchButton.Click();
            waitUntil(15, searchResult.searchResultInput);
        }

        [Then(@"verify that input of the search string begins from")]
        public void ThenVerifyThatInputOfTheSearchStringBeginsFrom(Table table)
        {
            var expectedResult = table.Rows[0]["searchResult"];
            var script = $"return document.getElementById('search_form_input').value;";

            var js = (IJavaScriptExecutor)driver;
            var str = js.ExecuteScript(script);

            StringAssert.StartsWith(expectedResult, str.ToString(), $"Input of the search string should be started from {expectedResult} but was {expectedResult}");
        }

        public void goToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void waitUntil(int timeOut, IWebElement expectedElements)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            wait.Until(d => expectedElements);
        }

        public void waitUntilJs(int timeOut)
        {
            var script = $"return document.getElementById('placeholder');";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            wait.Until(d => !((IJavaScriptExecutor)driver).ExecuteScript(script).ToString().Equals("0"));
        }

        [After]
        public void after()
        {
            driver.Quit();
        }

    }
}
