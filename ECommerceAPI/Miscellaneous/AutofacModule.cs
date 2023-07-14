using Autofac;
using ECommerceAPI.Contexts;
using ECommerceAPI.Interfaces;
using ECommerceAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Miscellaneous
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Repositories Dependency Injection
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CartItemRepository>().As<ICartItemRepository>().InstancePerLifetimeScope();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CheckoutRepository>().As<CheckoutRepository>().InstancePerLifetimeScope();

            //Dapper Dependency Injection
            builder.RegisterType<DapperContext>().SingleInstance();

        }
    }
}
