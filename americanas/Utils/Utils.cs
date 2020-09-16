using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace americanas
{
    public class Utils
    {
        private static string screenshotsFolder;
        private static int count = 1;

        ///<summary>Verifica se o usuário está logado</summary>
        public bool IsLogated(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://www.americanas.com.br/");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//a[@id='h_usr-link']")).Click();
            try
            {
                driver.FindElement(By.XPath("//a[@class='usr-signup']"));
                return false;
            }
            catch
            {
                return true;                
            }
        }

        public void Lougout(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//a[@class='usr-signout']")).Click();
            Thread.Sleep(3000);            
        }


        public bool Logated(IWebDriver driver)
        {
            try
            {
                driver.FindElement(By.XPath("h"));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsShowByXpath(IWebDriver driver, string path)
        {
            try
            {
                driver.FindElement(By.XPath(path));
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void CheckPageIsLoad(IWebDriver driver, string path)
        {
            if (IsShowByXpath(driver, path))
            {
                driver.FindElement(By.XPath(path));
            }
            else
            {
                Thread.Sleep(2000);
            }
        }
        public void InputTextById(IWebDriver driver, string element, string text)
        {
            driver.FindElement(By.Id(element)).Click();
            driver.FindElement(By.Id(element)).Clear();
            driver.FindElement(By.Id(element)).SendKeys(text);
        }

        public void ChoiceGender(IWebDriver driver, string gender)
        {
            if (Male(driver, gender))
            {
                driver.FindElement(By.XPath("//div[@id='gender']/div//label[@for='gender_M']")).Click();
            }
            else
            {
                driver.FindElement(By.XPath("//div[@id='gender']/div//label[@for='gender_F']")).Click();
            }
        }

        public bool Male(IWebDriver driver, string gender)
        {
            try
            {
                gender = "M";
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void EndPage(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector("body")).SendKeys(Keys.Control);
            driver.FindElement(By.CssSelector("body")).SendKeys(Keys.End);
        }

        public void Screenshot(IWebDriver driver)
        {
            screenshotsFolder = "C:\\VS-UN\\americanas\\americanas\\Screenshots\\";
            ITakesScreenshot camera = driver as ITakesScreenshot;
            Screenshot foto = camera.GetScreenshot();
            foto.SaveAsFile(screenshotsFolder + "americanas" + count + ".png", ScreenshotImageFormat.Png);
            count++;
        }
    }
}
