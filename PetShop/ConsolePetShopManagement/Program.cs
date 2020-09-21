using PetShop.Core.DomainService;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.ApplicationService.ApplicationService.Impl;
using PetShopApp.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            FakeDB.InitData();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            ////Build provider 
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.StartUI();
        }
    }
}
