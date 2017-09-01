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
    class ClientHandler
    {
        Thread clientThread;
        TcpClient newClient;

        NetworkStream nWS;
        StreamReader sR;
        StreamWriter sW;

        public ClientHandler(TcpClient newClient)
        {
            this.newClient = newClient;
            nWS = newClient.GetStream();
            sR = new StreamReader(nWS);
            sW = new StreamWriter(nWS);
            StartClient();
        }

        public void StartClient()
        {
            clientThread = new Thread(HandelClient);


            clientThread.Start();
        }
        
        public void HandelClient()
        {
            string text;
            while (true)
            {
                text = sR.ReadLine();
                Console.WriteLine(text);
                Broadcast.BroadcastToClients(text);
            }
        }
        public void SendToClient(string messageToClient)
        {
            sW.WriteLine(messageToClient);
            sW.Flush();
         
        }
    }
}
