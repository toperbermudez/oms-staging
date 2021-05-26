using OMS.Core.Entities;
using OMS.Core.Interface.Repositories;
using OMS.Core.Interface.Services;
using OMS.Repository.Repositories;
using OMS.Service.Services;
using System.Web.Http;
using System.Web.Mvc;
using Unity;


namespace OMS.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<ITestService, TestService>();
            container.RegisterType<IVariantService, VariantService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IAccountService, AccountService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<ICRUDRepository<Order>, CRUDRepository<Order>>();
            container.RegisterType<ICRUDRepository<Variant>, CRUDRepository<Variant>>();
            container.RegisterType<ICRUDRepository<Product>, CRUDRepository<Product>>();
            container.RegisterType<ICRUDRepository<Category>, CRUDRepository<Category>>();
            container.RegisterType<ICRUDRepository<User>, CRUDRepository<User>>();
            container.RegisterType<ICRUDRepository<Role>, CRUDRepository<Role>>();
            container.RegisterType<ICRUDRepository<Account>, CRUDRepository<Account>>();
            container.RegisterType<IUserQueryRepository, UserQueryRepository>();


            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}