using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using vending_machine.Models;
using vending_machine.Controllers;

namespace vending_machine.Tests
{
    /**
     * NOTE: We know putting test cases in main application is not a good practice. But we have to.
     * Because in this simple test (your request) we do not modularize controller and models as libraries.
     * So one unit test placed here and one integration test placed in a separate project.     
     **/
     
    [TestClass]
    public class TestBeverageController
    {
        [TestMethod]
        public void TestIndex()
        {
            var controller = new Controllers.BeverageController();
            ViewResult res = (ViewResult)controller.Index();
            Assert.IsTrue(((List<Beverage>)res.Model).Count == 4);
        }
    }
}