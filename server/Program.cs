using System;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerClass sc = new ServerClass();
            //no ipadr given - default using docker network
            if(args.Length == 0)
                sc.ServerStart();
            //ipadr given - run on local network, no docker overlay
            else
                sc.ServerStart(args[0]);
        }
    }
}
