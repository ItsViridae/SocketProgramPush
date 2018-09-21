using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketServerStart
{
    class JustARandomSocketProgram
    {
        static void Main(string[] args)
        {
            //create obj of socket class
            Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //create obj of ip adress
            IPAddress ipaddr = IPAddress.Any;

            //define an ip endpoint
            IPEndPoint ipep = new IPEndPoint(ipaddr, 23000);

            listenerSocket.Bind(ipep);

            //call listen method //parameter tells how many clients can wait for a connection at any time while the system is busy handling another connecetion 
            listenerSocket.Listen(5);

            Console.WriteLine("About to accept incommming connctions... ");

            //create socket class set a listenerSocket to accept the connection.
            Socket client = listenerSocket.Accept();

            //when connected with client display IP End Point #.#.#.#:PortNumber
            Console.WriteLine("Client connected. " + client.ToString() + " - IP End Point " + client.RemoteEndPoint.ToString());

            //assign possible bytes to an array
            byte[] buff = new byte[128];

          
            int numberOfRecievedBytes = 0;

            numberOfRecievedBytes = client.Receive(buff);


            Console.WriteLine("Number of received bytes: " + numberOfRecievedBytes);

            // This is WRONG!!!!Avoid concatenation of strings, just for example 
            Console.WriteLine("Data sent by client is " + buff);

            //this method is going to convert the bytes that received on the network into ASCII String for us
            //Encoding.ASCII.GetString(buff, 0, numberOfRecievedBytes);

            string receivedText = Encoding.ASCII.GetString(buff, 0, numberOfRecievedBytes);

            Console.WriteLine("Data sent by client is: " + receivedText);





        }
    }
}
