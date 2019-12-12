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
			containerBuilder.RegisterType<ProductRepository>().As<IProductRepository>();
			
			containerBuilder.RegisterType<ReportService>().As<IReportService>().EnableInterfaceInterceptors();
			containerBuilder.RegisterType<CacheInterceptor>().SingleInstance();

			containerBuilder.RegisterControllers(typeof(MvcApplication).Assembly);
			var container = containerBuilder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}