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
                int[] palya_merete = new int[2];
                char[,] palya;

                StreamReader sr = new StreamReader(args[0], Encoding.UTF8);

                string palya_neve = sr.ReadLine();

                string[] palya_meret_string = sr.ReadLine().Split(';');

                palya_merete[0] = Convert.ToInt32(palya_meret_string[0]);
                palya_merete[1] = Convert.ToInt32(palya_meret_string[1]);

                palya = new char[palya_merete[0], palya_merete[1]];
                int indexer = 0;
                while (!sr.EndOfStream)
                {
                    string temp = sr.ReadLine();
                    for (int i = 0; i < temp.Length; i++)
                    {
                        palya[indexer, i] = temp[i];
                    }
                    indexer++;
                }

                IPAddress local_IP = Dns.GetHostEntry("localhost").AddressList[1];
                int local_Port = 64320;
                IPEndPoint localEndPoint = new IPEndPoint(local_IP, local_Port);

                try {

                    Socket listener = new Socket(local_IP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    listener.Bind(localEndPoint);
                    listener.Listen(2);

                    Console.WriteLine($"Pop It szerver v1.0 - IP cím: {local_IP} Port: {local_Port}");
                    Console.WriteLine("Bejövő adatok várása...");
                    

                    string data = null;
                    byte[] bytes = null;
                    Socket handler = listener.Accept();
                    while (true)
                    {
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
     
                        if (data.Contains("STOP"))
                        {
                            break;
                        } else
                        {
                            Console.WriteLine($"Adat: {data}");
                            // adattal kezd valamit
                            data = null;
                        }
                    }
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();

                    //byte[] msg = Encoding.ASCII.GetBytes(data);
                    //handler.Send(msg);

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
