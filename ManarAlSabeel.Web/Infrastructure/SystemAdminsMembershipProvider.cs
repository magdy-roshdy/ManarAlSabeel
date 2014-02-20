using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ClientServices.Providers;
using System.Web.Security;

namespace ManarAlSabeel.Web.Infrastructure
{
	public class SystemAdminsMembershipProvider : ClientFormsAuthenticationMembershipProvider
	{
		public override bool ValidateUser(string username, string password)
		{
			return (
					(username == "admin@manaralsabeel.org" && password == "secret")
					||
					(username == "admin.females@manaralsabeel.org" && password == "password")
					);
		}
	}
}