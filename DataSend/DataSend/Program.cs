using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

// Teszt eszköz az adatok küldéséhez.

namespace DataSend
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipAdd = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEP = new IPEndPoint(ipAdd, 64320);
            soc.Connect(remoteEP);
            Console.WriteLine("Kezdj írni!");
            while (true)
            {
                byte[] byData = Encoding.ASCII.GetBytes($"{Console.ReadLine()}<EOF>");
                soc.Send(byData);
            }
            
            //soc.Shutdown(SocketShutdown.Both);
            //soc.Close();
            Console.ReadKey();
        }
    }
}
