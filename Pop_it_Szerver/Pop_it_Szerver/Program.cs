using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Net;

namespace Pop_it_Szerver
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                string palya_neve = "";
                int[] palya_merete = new int[2];
                char[,] palya;
                StreamReader sr = new StreamReader(args[0], Encoding.UTF8);
                palya_neve = sr.ReadLine();
                string[] palya_meret_string = sr.ReadLine().Split(';');
                palya_merete[0] = Convert.ToInt32(palya_meret_string[0]);
                palya_merete[1] = Convert.ToInt32(palya_meret_string[1]);

                IPAddress local_IP = Dns.GetHostEntry("localhost").AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(local_IP, 64320);

                try {

                    Socket listener = new Socket(local_IP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    listener.Bind(localEndPoint);
                    listener.Listen(2);

                    Console.WriteLine("Bejövő adatok várása...");
                    Socket handler = listener.Accept();

                    string data = null;
                    byte[] bytes = null;

                    while (true)
                    {
                        bytes = new byte[1024];
                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (data.IndexOf("<EOF>") > -1)
                        {
                            break;
                        }
                    }

                    Console.WriteLine("Megkapott adat: {0}", data);

                    byte[] msg = Encoding.ASCII.GetBytes(data);
                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }


            }
            else
            {
                Console.WriteLine("Felhasználás: popitserver.exe <pálya>");
            }
        }
    }
}
