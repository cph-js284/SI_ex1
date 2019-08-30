using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace server
{
    public class ServerClass
    {
        string message;
        byte[] buffer = new byte[1024];
        IPEndPoint endPoint;
        int port = 4545;
        IPAddress ipadr;
        Bank bank;

        public void ServerStart(string ipstr="172.17.0.2"){
            ipadr=IPAddress.Parse(ipstr);
            bank = new Bank(); 
            Listen();
        }

        private Socket CreateSocket(){
            endPoint = new IPEndPoint(ipadr, port);
            var socket = new Socket(ipadr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            System.Console.WriteLine("Socket created");
            return socket;
        }

        public void Listen(){
            var serverSocket = CreateSocket();
            serverSocket.Bind(endPoint);
            serverSocket.Listen(3); // 3 = queue length   
            System.Console.WriteLine($"Server running on: {ipadr}:{port}");

            try
            {

                while (true)
                {
                    System.Console.WriteLine("Server waiting for connection");
                    
                    Socket handler = serverSocket.Accept();
                    System.Console.WriteLine("Connection established");
                    
                    message="";
                    //reading
                    while (true)
                    {
                        var NumberOfBytes = handler.Receive(buffer);
                        message += Encoding.ASCII.GetString(buffer,0,NumberOfBytes);
                        //end of data received.
                        if(message.IndexOf("<##>") > -1)
                            break;
                    }
                    System.Console.WriteLine($"Data received: {message}");
                    //send reply to client
                    byte[] reply = null;
                    reply = Encoding.ASCII.GetBytes(bankStuff(message));
                    handler.Send(reply);
                    
                }             
            }
            catch (System.Exception)
            {
                throw new Exception("just blah ...");
            }

        }

        private string bankStuff(string data){
            try
            {
                var AccountNumber = int.Parse(message.Split(new char[]{'+','-'})[0]);
                var tmp =message.Split(new char[]{'+','-'})[1]; 
                var Amount = int.Parse(tmp.Substring(0,tmp.Length-4));
                Amount = message.Contains('-')? Amount*-1: Amount;
                return bank.DoBanking(AccountNumber, Amount);
            }
            catch (System.Exception)
            {
                return "Invalid format";                
            }

        }
    }
}