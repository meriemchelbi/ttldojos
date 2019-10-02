using System;
using GuessZoo.domain;
using GuessZoo.service;
using Microsoft.Extensions.DependencyInjection;

namespace GuessZoo
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ICardComparer, CardComparer>()
                .AddSingleton<ICardDescriptorComparisonRepository, CardDescriptorComparisonRepository>()
                .AddSingleton<IListLoaderSvc, ListLoaderSvc>()
                .AddSingleton<IManagementSvc, ManagementSvc>()
                .AddSingleton<IRandomCardPicker, RandomCardPicker>()
                .AddSingleton<IUserInterfaceService, UserInterfaceService>()
                .BuildServiceProvider();

            IManagementSvc managementSvc = (IManagementSvc)serviceProvider.GetService(typeof(IManagementSvc));
            IUserInterfaceService userInterfaceService = (IUserInterfaceService)serviceProvider.GetService(typeof(IUserInterfaceService));

            managementSvc.Start();
            
            userInterfaceService.PlayGame(managementSvc);
            
            Console.ReadKey();
        }


    }
}
