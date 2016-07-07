using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vending_machine.Models
{
    public class HotChocolate : HotBeverage
    {
        public override List<string> Phases
        {
            get
            {
                var list = base.Phases;
                list.Add("Add drinking chocolate to cup");
                list.Add("Add Water");
                return list;
            }
        }

        public override decimal ID
        {
            get
            {
                return 100;
            }            
        }

        public override string Name
        {
            get
            {
                return "Hot Chocolate";
            }            
        }

        public override decimal Price
        {
            get
            {
                return 100;
            }            
        }

        public override int InnerPhaseDelay
        {
            get
            {
                return 4000;
            }
        }

        public override int BetweenDelay
        {
            get
            {
                return 1500;
            }
        }
    }
}