using ManarAlSabeel.Domain.Abstract;
using ManarAlSabeel.Domain.Concrete;
using ManarAlSabeel.Domain.Entities;
using ManarAlSabeel.Web.Infrastructure.Abstract;
using ManarAlSabeel.Web.Infrastructure.Concrete;
using NHibernate;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManarAlSabeel.Web.Infrastructure
{
	public class NinjectControllerFactory : DefaultControllerFactory
	{
		private IKernel kernel;
		public NinjectControllerFactory()
		{
			kernel = new StandardKernel();
			AddBindings();
		}

		protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
		{
			//TEMP
			//new FormsAuthenticationProvider(new NHibernateCenterRepository(new SessionBasedDataBaseFilterProvider()))
			//	.Authenticate("magdy.roshdy@gmail.com", "password");

			return controllerType == null
			? null
			: (IController)kernel.Get(controllerType);
		}

		private void AddBindings()
		{
			var configuration = new NHibernate.Cfg.Configuration();
			configuration.Configure();
			configuration.AddAssembly(typeof(Student).Assembly);
			ISessionFactory sessionFactory = configuration.BuildSessionFactory();

			kernel.Bind<ICenterRepository>()
				.To<NHibernateCenterRepository>()
				.WithPropertyValue("SessionFactory", sessionFactory);

			kernel.Inject(new NHibernateCenterRepository(new ProfileBasedDataBaseFilterProvider()));

			kernel.Bind<IDataBaseFiltersProvider>().To<ProfileBasedDataBaseFilterProvider>();
			kernel.Bind<IAuthProvider>().To<FormsAuthenticationProvider>();
		}
	}
}