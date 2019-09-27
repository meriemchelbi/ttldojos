using System;
using GuessZoo.service;

namespace GuessZoo
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagementSvc managementSvc = new ManagementSvc();

            managementSvc.Run();
        }


    }
}
