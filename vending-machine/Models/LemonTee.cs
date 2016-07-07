using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vending_machine.Models
{
    public class LemonTee : HotBeverage
    {
        public override List<string> Phases
        {
            get
            {
                var list = base.Phases;
                list.Add("Add Sugar");
                list.Add("Add Water");
                list.Add("Steep tea bag in hot water");
                list.Add("Add Lemon");                
                return list;
            }
        }

        public override decimal ID
        {
            get
            {
                return 300;
            }
        }

        public override string Name
        {
            get
            {
                return "Lemon Tee";
            }
        }

        public override decimal Price
        {
            get
            {
                return 180;
            }
        }

        public override int InnerPhaseDelay
        {
            get
            {
                return 2000;
            }
        }

        public override int BetweenDelay
        {
            get
            {
                return 1000;
            }
        }
    }
}