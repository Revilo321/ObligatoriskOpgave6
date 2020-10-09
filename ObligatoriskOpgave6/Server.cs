using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace ObligatoriskOpgave6
{
    class Server
    {
        private static List<FanOutPut> fans = new List<FanOutPut>
        {
            new FanOutPut(1, "DR24", 25, 50),
            new FanOutPut(2,"DR25",17,35),
            new FanOutPut(3,"DR26",20,40),
            new FanOutPut(4,"DR27",23,66),
            new FanOutPut(5,"DR28",15,30)
        };


        public void Start()
        {
            //Connection åbnes
            IPAddress localAddress = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(localAddress, 4646);

            listener.Start();
            Console.WriteLine("Server started!");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Client connected!");

                TcpClient tempSocket = client;
                DoClient(tempSocket);
            }
        }


        public void DoClient(TcpClient client)
        { 

            //Stream writer/reader til at læse og udskrive
            NetworkStream ns = client.GetStream();


           StreamReader sr = new StreamReader(ns);
           StreamWriter sw = new StreamWriter(ns);

            sw.AutoFlush = true;

            string message = sr.ReadLine();

            while (message != null && message != "")
            {

                //Splitter min string, tager første index altså 0 som command og laver en switch statement til den.
                //Parameter sættes til indexet af ' ' + 1
                string[] msgArray = message.Split(' ');
                string parameter = message.Substring(message.IndexOf(' ') + 1);
                string command = msgArray[0];


                switch (command)
                {
                    case "HentAlle":
                        sw.WriteLine(JsonConvert.SerializeObject(fans));
                        break;
                    case "Hent":
                        sw.WriteLine(JsonConvert.SerializeObject(fans.Find(i=> i.Id.ToString() == parameter)));
                        break;
                    case "Gem":
                        FanOutPut saveFan = JsonConvert.DeserializeObject<FanOutPut>(parameter);
                        fans.Add(saveFan);
                        break;
                    
                }

                message = sr.ReadLine();
            }

            //Connection lukkes
            ns.Close();
            Console.WriteLine("Client disconnected!");



        }

    }
}
