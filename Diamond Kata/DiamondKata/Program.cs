using System;
using DiamondKata.service;

namespace DiamondKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var orchestrationSvc = new OrchestrationSvc();
            var userInterfaceSvc = new UserInterfaceSvc();

            while (true)
            {
                userInterfaceSvc.Play(orchestrationSvc);
            }

           
        }
    }
}
