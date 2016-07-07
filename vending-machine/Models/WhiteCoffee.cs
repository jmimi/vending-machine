using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vending_machine.Models
{
    public class WhiteCoffee : HotBeverage
    {
        public override List<string> Phases
        {
            get
            {
                var list = base.Phases;                
                list.Add("Add Sugar");
                list.Add("Add coffee granules to cup");                
                list.Add("Add Water");
                list.Add("Add Milk");
                return list;
            }
        }

        public override decimal ID
        {
            get
            {
                return 200;
            }
        }

        public override string Name
        {
            get
            {
                return "White Coffee with 1 sugar";
            }
        }

        public override decimal Price
        {
            get
            {
                return 300;
            }
        }

        public override int InnerPhaseDelay
        {
            get
            {
                return 5000;
            }
        }

        public override int BetweenDelay
        {
            get
            {
                return 2000;
            }
        }
    }
}