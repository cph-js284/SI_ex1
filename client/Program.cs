using System;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientClass CC;
            string data="";

            if(args.Length == 0)
                CC = new ClientClass();
            else 
                CC = new ClientClass(args[0]);

            System.Console.WriteLine("----------------------------------------------------------------------");
            System.Console.WriteLine("----------------------------------------------------------------------");
            System.Console.WriteLine("FORMAT: <Enter AccountNumber (0-9)><Enter Amount (-x to withdraw, +x to deposit)>");
            System.Console.WriteLine("Example: 2+100 => will deposit 100 to account #2.");
            System.Console.WriteLine("Example: 2-50 => will withdraw 50 from account #2");
            System.Console.WriteLine("\nType exit to shutdown");
            System.Console.WriteLine("----------------------------------------------------------------------");
            System.Console.WriteLine("----------------------------------------------------------------------");

            while (true)
            {
                System.Console.WriteLine("Enter command:");
                data = data = Console.ReadLine();
                if (data == "exit")
                    break;
                CC.StartClient(data);
                System.Console.WriteLine("************************************");                
            }
            
        }
    }
}
