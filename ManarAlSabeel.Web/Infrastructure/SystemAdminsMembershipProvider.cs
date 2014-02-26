using ManarAlSabeel.Domain.Abstract;
using ManarAlSabeel.Domain.Entities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ClientServices.Providers;

namespace ManarAlSabeel.Web.Infrastructure
{
	public class SystemAdminsMembershipProvider : ClientFormsAuthenticationMembershipProvider
	{
		[Inject]
		public ICenterRepository DBRepository { get; set; }

		public override bool ValidateUser(string username, string password)
		{
			SystemAdmin admin = DBRepository.AuthenticateSystemAdmin(username, password);
			return (admin != null && admin.IsActive);
		}
	}
}