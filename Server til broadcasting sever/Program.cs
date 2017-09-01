using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server_til_broadcasting_sever
{
    class Program
    {
        TcpListener listner = new TcpListener(IPAddress.Any, 11000);
        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.Run();
        }
        public void Run()
        {
            listner.Start();
            TcpClient tempClient;
            ClientHandler clienthandler;
            while (true)
            {
                tempClient = listner.AcceptTcpClient();
                Console.WriteLine("Here you are");
                clienthandler = new ClientHandler(tempClient);
                Broadcast.addClientToList(clienthandler);
            }
        }
    }
}
