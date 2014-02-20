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
		public bool Authenticate(string username, string password)
		{
			return Membership.Provider.ValidateUser(username, password);
		}
	}
}