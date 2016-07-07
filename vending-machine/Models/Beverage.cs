using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vending_machine.Utils;

namespace vending_machine.Models
{
    public abstract class Beverage
    {
        public virtual decimal ID { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string Name { get; set; }
        public Connection Connection { get; set; }
        public virtual List<string> Phases { get; private set; }
        public virtual int InnerPhaseDelay { get; private set; }
        public virtual int BetweenDelay { get; private set; }

        public void Process()
        {            
            SendStatus("Order", "Started");
            Delay(1000);
            foreach (string phase in Phases)
            {
                ProcessPhase(phase);
            }
            Delay(1000);
            SendStatus("Order", "Finished");
        }
        protected void SendStatus(string phase, string status)
        {
            Communication.SendProcessingPhase(Connection.ID, phase, status);
        }
        protected void ProcessPhase(string phase)
        {
            SendStatus(phase, "Started");
            Delay(InnerPhaseDelay);
            SendStatus(phase, "Finished");
            Delay(BetweenDelay);
        }

        protected void Delay(int time)
        {
            System.Threading.Thread.Sleep(time);
        }
    }
}
