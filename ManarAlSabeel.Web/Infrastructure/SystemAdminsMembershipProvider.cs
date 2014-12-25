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
			SystemAdmin admin = DBRepository.GetSystemAdminByEmail(username);
			
			if (admin == null)
				return false;
			if (!admin.IsActive)
				return false;

			bool isValid = SecurityHelper.VerifyHash(password, admin.Password);
			if(isValid)
			{
				DBRepository.UpdateSystemAdminLastLogin(admin.ID, DateTime.Now);
			}

			return isValid;
		}
	}
}