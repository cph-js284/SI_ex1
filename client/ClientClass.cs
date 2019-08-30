using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace client
{
    public class ClientClass
    {
        byte[] buffer = new byte[1024];
        int port = 4545;
        IPAddress ipadr;
        IPEndPoint endPoint;

        public ClientClass(string ipstr="172.17.0.2")
        {
            ipadr = IPAddress.Parse(ipstr);
        }

        private Socket CreateSocket(){
            endPoint = new IPEndPoint(ipadr, port);
            var clientSocket = new Socket(ipadr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            return clientSocket;
        }

        public void StartClient(string _message){
            try
            {
                var SenderSocket = CreateSocket();
                SenderSocket.Connect(endPoint);
                System.Console.WriteLine($"Connection established to remote host: {SenderSocket.RemoteEndPoint.ToString()}");

                var message = _message+"<##>";
                //send msg to server
                SenderSocket.Send(Encoding.ASCII.GetBytes(message));
                //waiting for reply from server
                Array.Clear(buffer,0,buffer.Length); // clearing previous message in buffer
                SenderSocket.Receive(buffer);
                System.Console.WriteLine($"RESPONSE:: {Encoding.ASCII.GetString(buffer,0,buffer.Length)}");

                //close connection                
                SenderSocket.Close();

            }
            catch (System.Exception)
            {
                
                throw new Exception("meh...");
            }


        }
    }
}