using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace vending_machine.Utils
{
    [HubName("beverage")]
    public class BeverageProcessingHub : Hub
    {        
        public void SendProcessPhase(string ID, string phase, string status)
        {
            Clients.Client(Connections.ById(ID).ConnectionId).send(phase, status);
        }

        public override System.Threading.Tasks.Task OnConnected()
        {
            string Id = Context.QueryString["ID"];
            Connections.Add(Id, Context.ConnectionId);
            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected()
        {
            //Connections.RemoveByConnectionId(Context.ConnectionId);
            return base.OnDisconnected();
        }
    }
}