using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vending_machine.Utils
{
    public sealed class Connections
    {
        private static List<Connection> Customers = new List<Connection>();
        public static void Add(string ID, string ConnectionId)
        {
            Connection conn = new Connection() { ConnectionId = ConnectionId, ID = ID };
            Customers.Add(conn);
        }

        public static void RemoveByID(string id)
        {
            Connection conn = Customers.Single(c => c.ID.Equals(id));
            if (conn != null)
            {
                Customers.Remove(conn);
            }
        }

        public static void RemoveByConnectionId(string id)
        {
            Connection conn = Customers.Single(c => c.ConnectionId.Equals(id));
            if (conn != null)
            {
                Customers.Remove(conn);
            }
        }

        public static Connection ByConnectionId(string id)
        {
            return Customers.Single(c => c.ConnectionId.Equals(id));
        }

        public static Connection ById(string id)
        {
            return Customers.Single(c => c.ID.Equals(id));
        }
    }

    public sealed class Connection
    {
        public string ConnectionId { get; set; }
        public string ID { get; set; }
    }
}