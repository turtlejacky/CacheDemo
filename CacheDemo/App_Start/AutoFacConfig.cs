using System.Web.Mvc;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Autofac.Integration.Mvc;
using CacheDemo.Models;

namespace CacheDemo
{
	public class AutoFacConfig
	{
		public void Register()
		{
			var containerBuilder = new ContainerBuilder();
			containerBuilder.RegisterType<MemoryCacheProvider>().As<ICacheProvider>().SingleInstance();
			containerBuilder.RegisterType<ReportService>().As<ReportService>();
			containerBuilder.RegisterType<ProductRepository>().As<IProductRepository>().SingleInstance();
			containerBuilder.RegisterControllers(typeof(MvcApplication).Assembly);
			var container = containerBuilder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}