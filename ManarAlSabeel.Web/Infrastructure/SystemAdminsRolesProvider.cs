using ManarAlSabeel.Domain.Abstract;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ClientServices.Providers;
using System.Web.Mvc;
using System.Web.Security;

namespace ManarAlSabeel.Web.Infrastructure
{
	public class SystemAdminsRolesProvider : ClientRoleProvider
	{
		[Inject]
		public ICenterRepository DBRepository { get; set; }

		public override string[] GetRolesForUser(string username)
		{
			try
			{
				string x = DBRepository.GetType().ToString();
			}
			catch { }
			return new string[] { "admin", "manager", "superAdmin" };
		}
	}
}