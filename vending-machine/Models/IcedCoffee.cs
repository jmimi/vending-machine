using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vending_machine.Models
{
    public class IcedCoffee : Beverage
    {
        public override List<string> Phases
        {
            get
            {
                var list = new List<string>();
                list.Add("Crush Ice");
                list.Add("Add ice to blender");
                list.Add("Add coffee syrup to blender");
                list.Add("Blend ingredients");
                list.Add("Add ingredients");
                return list;
            }
        }

        public override decimal ID
        {
            get
            {
                return 400;
            }
        }

        public override string Name
        {
            get
            {
                return "Iced Coffee";
            }
        }

        public override decimal Price
        {
            get
            {
                return 240;
            }
        }

        public override int InnerPhaseDelay
        {
            get
            {
                return 3000;
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