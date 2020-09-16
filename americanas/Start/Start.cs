using System.Text;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using TestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;
using americanas.Search;
using americanas.Login;


namespace americanas
{
    [TestClass]
    public class Start
    {
        private Utils utils = new Utils();
        private static IWebDriver driver; //= new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        private StringBuilder verificationErrors;

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            driver = new ChromeDriver(".");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(180);
        }

        [ClassCleanup]
        public static void CleanupClass()
        {
            try
            {
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                
            }
        }

        [TestInitialize]
        public void InitializeTest()
        {
            verificationErrors = new StringBuilder();
        }

        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
            utils.Screenshot(driver);
        }

        [TestMethod]
        public void TestSignup()
        {
            new TestSignup(driver, verificationErrors);
        }

        [TestMethod]
        public void TestSearch()
        {
            new TestSearch(driver, verificationErrors);
        }

    }
}
