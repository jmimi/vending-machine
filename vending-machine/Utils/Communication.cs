using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vending_machine.Utils
{
    public static class Communication
    {
        private static IHubContext ProcessingHub
        {
            get
            {
                return GlobalHost.ConnectionManager.GetHubContext<BeverageProcessingHub>();
            }
        }
        public static void SendProcessingPhase(string ID, string phase, string status)
        {
            ProcessingHub.Clients.Client(Connections.ById(ID).ConnectionId).sendProcesingPhase(phase, status);
        }
    }
}