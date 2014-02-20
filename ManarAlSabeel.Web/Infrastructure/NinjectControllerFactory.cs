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
using System.Web.Profile;
using System.Web.Security;

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

			kernel.Inject(Membership.Provider);
			kernel.Inject(Roles.Provider);
			kernel.Inject(ProfileManager.Provider);
		}
	}
}