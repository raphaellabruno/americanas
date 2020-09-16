using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Assert = NUnit.Framework.Assert;
namespace americanas.Login
{
    public class TestSignup
    {
        ///<summary>Cria um novo usuário</summary>
        public TestSignup(IWebDriver driver, StringBuilder verificationsErrors)
        {
            Utils utils = new Utils();
            if (utils.IsLogated(driver))
            {
                utils.Lougout(driver);
            }

            driver.FindElement(By.XPath("//a[@id='h_usr-link']")).Click();
            driver.FindElement(By.XPath("//a[@class='usr-signup']")).Click();
            Thread.Sleep(3000);

            utils.InputTextById(driver, "email-input", "teste@hotmail.com");
            utils.InputTextById(driver, "password-input", "la");

            utils.EndPage(driver);

            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            Thread.Sleep(3000);
            //Parar pra fazer o caphca

            //Verificar mensagem "fraca"
            Assert.AreEqual("fraca", driver.FindElement(By.XPath("//div[@id='password']/div/span")).Text);

            //Verificar mensagem "Email já cadastrado"
            Assert.AreEqual("E-mail já cadastrado", driver.FindElement(By.XPath("//div[@id='email']/div")).Text);

            utils.InputTextById(driver, "cpf-input", "111.111.111-11");
            utils.InputTextById(driver, "email-input", "kZuy4dhk@hotmail.com");
            utils.InputTextById(driver, "password-input", "kZuy4dhk");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            Thread.Sleep(3000);
            //Parar pra fazer o capcha

            //Verificar mensagem "CPF inválido"
            Assert.AreEqual("CPF inválido.", driver.FindElement(By.XPath("//div[@id='cpf']/div")).Text);
            
            utils.InputTextById(driver, "cpf-input", "237.632.580-35");
            utils.InputTextById(driver, "name-input", "José Carlos");
            utils.InputTextById(driver, "birthday-input", "01/01/2000");
            utils.ChoiceGender(driver, "M");
            utils.InputTextById(driver, "phone-input", "(19) 99999-9900");
            driver.FindElement(By.XPath("//label[@for='receiveWhatsApp']")).Click();
            utils.EndPage(driver);
            driver.FindElement(By.XPath("//div[@id='cellphone']//input[@id='phone-input']")).Click();
            driver.FindElement(By.XPath("//div[@id='cellphone']//input[@id='phone-input']")).Clear();
            driver.FindElement(By.XPath("//div[@id='cellphone']//input[@id='phone-input']")).SendKeys("(19) 99999-9900");

            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            Thread.Sleep(3000);
            //Parar pra fazer o capcha

        }
    }
}
