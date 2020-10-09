using System;

namespace ObligatoriskOpgave6
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Start();
            Console.ReadLine();
        }
    }
}
