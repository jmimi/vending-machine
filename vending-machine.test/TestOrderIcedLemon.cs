using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace vending_machine.test
{
    [TestClass]
    public class TestOrderIcedLemon : BaseIntegrationTest
    {
        public TestOrderIcedLemon() : base("vending-machine") { }

        [TestMethod]
        public void TestOrder()
        {
            FirefoxDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/Beverage/Order/400"));
            WebDriverWait wait = new WebDriverWait(FirefoxDriver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.Id("ready_state"), "Ready!"));                      
            FirefoxDriver.FindElementById("start_process").Click();
            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#result p:last-child"), "Order Finished"));                      
            Assert.IsTrue(FirefoxDriver.FindElementById("result").FindElement(By.TagName("p")).Displayed);            
        }
    }
}
