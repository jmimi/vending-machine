using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using vending_machine.Utils;

namespace vending_machine.Models
{
    public abstract class HotBeverage : Beverage
    {
        public override List<string> Phases
        {
            get
            {
                List<string> list = new List<string>();
                list.Add("Boil Water");
                return list;
            }            
        }       
    }
}