using ManarAlSabeel.Domain.Abstract;
using ManarAlSabeel.Web.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Security;

namespace ManarAlSabeel.Web.Infrastructure.Concrete
{
	public class FormsAuthenticationProvider : IAuthProvider
	{
		private ICenterRepository dbRepository;
		public FormsAuthenticationProvider(ICenterRepository repo)
		{
			dbRepository = repo;
		}

		public bool Authenticate(string username, string password)
		{
			bool result = validateLogin(username, password);
			if (result)
			{
				FormsAuthentication.SetAuthCookie(username, false);
			}

			return result;
		}

		private bool validateLogin(string email, string password)
		{
			return (
					(email == "admin@manaralsabeel.org" && password == "secret")
					||
					(email == "admin.females@manaralsabeel.org" && password == "password")
					);
		}
	}
}