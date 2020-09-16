using americanas.Login;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Assert = NUnit.Framework.Assert;

namespace americanas.Search
{
    public class TestSearch
    {
        private StringBuilder verificationErrors;
        private string parcel;
        private bool max;
        private bool minor;
        private double value;
        private string valueString;

        ///<summary> </summary>
        public TestSearch(IWebDriver driver, StringBuilder verificationsErrors)
        {
            Utils utils = new Utils();

            if (!utils.IsLogated(driver))
            {
                new TestSignup(driver, verificationErrors);
            }

            //Pesquisa
            utils.InputTextById(driver, "h_search-input", "g6");
            driver.FindElement(By.Id("h_search-btn")).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.CssSelector("body")).SendKeys(Keys.PageDown);

            //Clica no primeiro resultado
            driver.FindElement(By.XPath("//div[@id='content-middle']/div[6]/div/div/div/div/div/div/div[2]/a/section/div[2]/div/h2")).Click();
            driver.FindElement(By.CssSelector("body")).SendKeys(Keys.PageDown);
            driver.FindElement(By.XPath("//a[@id='btn-buy']/div")).Click();
            Thread.Sleep(3000);

            //Continua
            driver.FindElement(By.XPath("//button[@id='btn-continue']/div")).Click();
            Thread.Sleep(3000);

            //Comprar
            driver.FindElement(By.CssSelector("body")).SendKeys(Keys.PageDown);
            driver.FindElement(By.Id("buy-button")).Click();
            Thread.Sleep(3000);

            //Endereço
            try
            {
                //cpf
                utils.InputTextById(driver, "edit-recipientDocumentNumber", "237.632.580-35");
                utils.InputTextById(driver, "edit-cep", "11662-190");
                Thread.Sleep(3000);
                utils.InputTextById(driver, "edit-number", "111");
                utils.InputTextById(driver, "edit-reference", "Algum Lugar");
                driver.FindElement(By.XPath("//form[@id='editAddress']/div[3]/div[2]/button")).Click();
            }
            catch
            {

            }

            //Verificando se minha compra é menor que 5000
            valueString = driver.FindElement(By.XPath("//html[@id='ng-app']/body/section/div/section/div/new-payment-summary/section/div/div/ul/li/span[2]")).Text;
            valueString = valueString.TrimStart('R', '$', ' ');
            value = Convert.ToDouble(valueString);
            minor = value < 5000;
            Assert.True(minor);

            driver.FindElement(By.CssSelector("body")).SendKeys(Keys.PageDown);
            driver.FindElement(By.CssSelector("body")).SendKeys(Keys.PageDown);

            //Número do cartão
            driver.FindElement(By.XPath("(//input[@type='tel'])[11]")).Click();
            driver.FindElement(By.XPath("(//input[@type='tel'])[11]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='tel'])[11]")).SendKeys("6062.8230.6427.6030");

            //Nome impresso no cartão
            driver.FindElement(By.XPath("(//input[@type='text'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@type='text'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[2]")).SendKeys("José Aparecido");

            //Codigo de segurança
            driver.FindElement(By.XPath("(//input[@type='tel'])[12]")).Click();
            driver.FindElement(By.XPath("(//input[@type='tel'])[12]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='tel'])[12]")).SendKeys("677");

            //Parcelas
            driver.FindElement(By.XPath("(//input[@type='number'])[6]")).Click();
            driver.FindElement(By.XPath("(//input[@type='number'])[6]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='number'])[6]")).SendKeys("10");

            //Seleciona o mês 6
            driver.FindElement(By.XPath("//select[contains(@class,'creditCardForm-expiryMonth')]//option[@value='5']")).Click();

            //Seleciona 2021
            driver.FindElement(By.XPath("//select[contains(@class,'creditCardForm-expiryYear')]//option[@value='1']")).Click();

            parcel = driver.FindElement(By.XPath("//article[@id='payment-option-CREDIT_CARD']/div/div/new-credit-card-payment/section/single-card-payment/ul/new-card-radio-input/li/form/p/span")).Text;
            String[] vet = parcel.Split(' '); //-criou um vetor e vai armazenar cortando no espaço
            parcel = vet[0];

            //Verifica se o foi parcelado em 10x
            max = parcel == "10X";
            Assert.True(max);
                       
        }
    }
}
