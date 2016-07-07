using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vending_machine.Models;
using vending_machine.Utils;

namespace vending_machine.Controllers
{
    public class BeverageController : Controller
    {
        private static List<Beverage> _Beverages;
        private static List<Beverage> Beverages
        {
            get
            {
                if (_Beverages == null)
                {
                    _Beverages = new List<Beverage>();
                    _Beverages.Add(new HotChocolate());
                    _Beverages.Add(new WhiteCoffee());
                    _Beverages.Add(new LemonTee());
                    _Beverages.Add(new IcedCoffee());
                }
                return _Beverages;
            }
        }

        //
        // GET: /Beverage/
        public ActionResult Index()
        {            
            return View(Beverages);
        }

        public ActionResult Order(int id)
        {
            var beverage = Beverages.Single(b => b.ID.Equals(id));
            return View(beverage);
        }

        public void StartProcess(int id, int random)
        {
            var beverage = Beverages.Single(b => b.ID.Equals(id));
            beverage.Connection = Connections.ById(random.ToString());
            beverage.Process();
        }
    }
}
