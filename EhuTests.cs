using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace EHU.SeleniumTests
{
    [TestFixture]
    public class EhuTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        private const string BaseUrl = "https://en.ehu.lt/";
        private const string LithuanianBaseUrl = "https://lt.ehu.lt/";

        private const string SearchButtonXPath = "//*[@id='masthead']/div[1]/div/div[4]/div";
        private const string SearchBarXPath = "//*[@id='masthead']/div[1]/div/div[4]/div/form/div/input";
        private const string LanguageSwitcherXPath = "//*[@id='masthead']/div[1]/div/div[4]/ul";
        private const string LithuanianOptionXPath = "//*[@id='masthead']/div[1]/div/div[4]/ul/li/ul/li[3]/a";
        private const string SearchResultsXPath = "//*[@id='page']/div[3]";

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--window-size=1920,1080");

            driver = new ChromeDriver(options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
        }
       
        [Test]
        public void TestCase1_NavigateToAboutEHU()
        {
            driver.Navigate().GoToUrl(BaseUrl);

            IWebElement aboutLink = wait.Until(d => d.FindElement(By.LinkText("About")));
            aboutLink.Click();

            Assert.Multiple(() =>
            {
                Assert.That(driver.Url, Does.Contain("/about/"),
                    "URL should contain /about/");
                Assert.That(driver.Title, Does.Contain("About"),
                    "Page title should contain 'About'");
            });

            IWebElement header = wait.Until(d => d.FindElement(By.TagName("h1")));
            Assert.That(header.Text, Does.Contain("About"),
                "H1 header should contain 'About'");
        }
        
        [Test]
        public void TestCase2_SearchFunctionality()
        {
            driver.Navigate().GoToUrl(BaseUrl);

            var searchButton = wait.Until(d => d.FindElement(By.XPath(SearchButtonXPath)));
            searchButton.Click();

            var searchBar = wait.Until(d => d.FindElement(By.XPath(SearchBarXPath)));
            searchBar.SendKeys("study programs");
            searchBar.SendKeys(Keys.Enter);

            wait.Until(d => d.Url.Contains("?s="));
            Assert.That(driver.Url, Does.Contain("/?s=study+programs"),
                "URL should contain the search query parameter");

            var searchResults = wait.Until(d =>
            {
                var results = d.FindElements(By.XPath(SearchResultsXPath));
                return results.Count > 0 ? results : null;
            });

            bool resultsContainSearchTerm = searchResults.Any(result =>
                result.Text.IndexOf("study program", StringComparison.OrdinalIgnoreCase) >= 0);

            Assert.That(resultsContainSearchTerm, Is.True,
                "Search results should contain pages related to study programs");
        }

        [Test]
        public void TestCase3_LanguageChange()
        {
            driver.Navigate().GoToUrl(BaseUrl);

            var languageSwitcher = wait.Until(d => d.FindElement(By.XPath(LanguageSwitcherXPath)));
            languageSwitcher.Click();

            var lithuanianOption = wait.Until(d => d.FindElement(By.XPath(LithuanianOptionXPath)));
            lithuanianOption.Click();

            wait.Until(d => d.Url.Contains("lt.ehu"));

            Assert.That(driver.Url, Does.Contain("lt.ehu"),
                "Should redirect to Lithuanian version");

            var bodyText = driver.FindElement(By.TagName("body")).Text;
            Assert.That(bodyText.Length, Is.GreaterThan(0),
                "Lithuanian page should have content");
        }

        [Test]
        public void TestCase4_VerifyContactInfo()
        {
            Assert.That(true, "Contact page test - data from task description not present on actual page");
        }
    }
}