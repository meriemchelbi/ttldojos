using System;
using DiamondKata.service;

namespace DiamondKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var managementSvc = new ManagementSvc();
            var userInterfaceSvc = new UserInterfaceSvc();

            while (true)
            {
                userInterfaceSvc.Play(managementSvc);
            }

           
        }
    }
}
