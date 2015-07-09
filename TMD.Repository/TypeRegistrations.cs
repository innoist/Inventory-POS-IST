using System.Data.Entity;
using TMD.Interfaces.IRepository;
using TMD.Repository.BaseRepository;
using TMD.Repository.Repositories;
using Microsoft.Practices.Unity;
namespace TMD.Repository
{
    public static class TypeRegistrations
    {
        public static void RegisterType(IUnityContainer unityContainer)
        {
            
            unityContainer.RegisterType<IAspNetUserRepository, AspNetUserRepository>();
            unityContainer.RegisterType<IStagingEbayBatchImportsRepository, StagingEbayBatchImportsRepository>();
            unityContainer.RegisterType<IStagingEbayItemRepository, StagingEbayItemRepository>();
            unityContainer.RegisterType<IConfigurationRepository, ConfigurationRepository>();
            unityContainer.RegisterType<DbContext, BaseDbContext>(new PerRequestLifetimeManager());
            unityContainer.RegisterType<IProductCategoryRepository, ProductCategoryRepository>();
            unityContainer.RegisterType<IProductRepository, ProductRepository>();
            unityContainer.RegisterType<IVendorRepository, VendorRepository>();
            unityContainer.RegisterType<IInventoryItemRepositoy, InventoryItemRepository>();
            unityContainer.RegisterType<IOrderItemsRepository, OrderItemsRepository>();
            unityContainer.RegisterType<IOrdersRepository, OrdersRepository>();
            unityContainer.RegisterType<IProductConfigurationRepositoy, ProductConfigurationRepository>();
            unityContainer.RegisterType<ICustomerRepository, CustomerRepository>();
            unityContainer.RegisterType<IExpenseCategoryRepository, ExpenseCategoryRepository>();
            unityContainer.RegisterType<IExpenseRepository, ExpenseRepository>();
        }
    }
}
