using ManarAlSabeel.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ManarAlSabeel.Web.Infrastructure
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
			bool result = Membership.ValidateUser(username, password);
			if (result)
			{
				FormsAuthentication.SetAuthCookie(username, false);
				HttpContext.Current.Session["sex-filter"] = 1;
				HttpContext.Current.Session["branch-filter"] = 1;
			}

			return result;
		}
	}
}