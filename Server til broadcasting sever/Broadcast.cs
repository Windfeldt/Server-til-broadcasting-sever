using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Server_til_broadcasting_sever
{
    static class Broadcast
    {
        static List<ClientHandler> clientList = new List<ClientHandler>();


        
        static public void addClientToList(ClientHandler client)
        {
            clientList.Add(client);
        }
        static public void BroadcastToClients(string messsageToAll)
        {
            foreach (ClientHandler client in clientList)
            {
                client.SendToClient(messsageToAll);
            }
        }
    }
}
