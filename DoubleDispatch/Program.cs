using DoubleDispatch.Core.Purchase.Aggregates;
using DoubleDispatch.Core.Purchase.Contracts;
using DoubleDispatch.Core.Purchase.Services;
using DoubleDispatch.Infrastrcuture;
using DoubleDispatch.Infrastrcuture.Purchase;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace DoubleDispatch
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();

            //Usecase 1
            AddItemAboveLimitReturnFalse(serviceProvider);

            //Usecase 2
            UpdateItemAboveLimitReturnsFalse(serviceProvider);

            Console.ReadKey();
        }

        private static void AddItemAboveLimitReturnFalse(IServiceProvider serviceProvider)
        {
            var _purchaseOrderRepo = serviceProvider.GetRequiredService<IPurchaseOrderRepository>();
            var _purchaseOrderSvc = serviceProvider.GetRequiredService<IPurchaseOrderService>();
            var _bus = serviceProvider.GetRequiredService<IBus>();

            var po = PurchaseOrder.CreatePurchase(spendLimit: 100);

            _purchaseOrderRepo.Add(po);

            po.TryAddItem(LineItem.CreateLineItem(po.Id, 50), _purchaseOrderSvc);
            po.TryAddItem(LineItem.CreateLineItem(po.Id, 51), _purchaseOrderSvc);

            foreach (var @event in po.DomainEvents)
            {
                _bus.Dispatch(@event);
            }
        }

        private static void UpdateItemAboveLimitReturnsFalse(IServiceProvider serviceProvider)
        {
            var _purchaseOrderRepo = serviceProvider.GetRequiredService<IPurchaseOrderRepository>();
            var _purchaseOrderSvc = serviceProvider.GetRequiredService<IPurchaseOrderService>();
            var _bus = serviceProvider.GetRequiredService<IBus>();

            var po = PurchaseOrder.CreatePurchase(spendLimit: 100);

            _purchaseOrderRepo.Add(po);
            po.TryAddItem(LineItem.CreateLineItem(po.Id, 50), _purchaseOrderSvc);
            

            var item = LineItem.CreateLineItem(po.Id, 25);          
            po.TryAddItem(item, _purchaseOrderSvc);

            po.TryUpdateCost(51, item.Id, _purchaseOrderSvc);

            foreach (var @event in po.DomainEvents)
            {
                _bus.Dispatch(@event);
            }
        }


        private static IServiceProvider ConfigureServices()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot configuration = builder.Build();

            IServiceCollection services = new ServiceCollection();
            services.AddScoped<IPurchaseOrderRepository, InMemoryPurchaseOrderRepository>();
            services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IBus, MediatrBus>();

            return services.BuildServiceProvider();
        }
    }
}
