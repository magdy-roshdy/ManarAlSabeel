using ManarAlSabeel.Domain.Abstract;
using ManarAlSabeel.Domain.Entities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace ManarAlSabeel.Web.Infrastructure
{
	public class SystemAdminsProfileProvider : ProfileProvider
	{
		[Inject]
		public ICenterRepository DBRepository { get; set; }

		private IDictionary<string, IDictionary<string, object>> data = new Dictionary<string, IDictionary<string, object>>();
		public SystemAdminsProfileProvider()
		{
			Dictionary<string, object> maleFilters = new Dictionary<string, object>();

			Branch branch = new Branch { Name = "الفرع الرئيسي", ID = 1, Center = new Center { Name = "مركز منار السبيل", ID = 1 } };
			maleFilters.Add("SexFilter", 1);
			maleFilters.Add("BranchFilter", branch);
			data.Add("admin@manaralsabeel.org", maleFilters);

			Dictionary<string, object> femaleFilters = new Dictionary<string, object>();
			femaleFilters.Add("SexFilter", 0);
			femaleFilters.Add("BranchFilter", branch);
			data.Add("admin.females@manaralsabeel.org", femaleFilters);
		}

		public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
		{
			SettingsPropertyValueCollection result = new SettingsPropertyValueCollection();
			IDictionary<string, object> userData;
			string userName = (string)context["UserName"];
			bool userDataExists = data.TryGetValue(userName, out userData);
			foreach (SettingsProperty prop in collection)
			{
				SettingsPropertyValue spv = new SettingsPropertyValue(prop);
				if (userDataExists)
				{
					spv.PropertyValue = userData[prop.Name];
				}
				result.Add(spv);
			}

			return result;
		}

		public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
		{
			//
		}

		public override int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
		{
			throw new NotImplementedException();
		}

		public override int DeleteProfiles(string[] usernames)
		{
			throw new NotImplementedException();
		}

		public override int DeleteProfiles(ProfileInfoCollection profiles)
		{
			throw new NotImplementedException();
		}

		public override ProfileInfoCollection FindInactiveProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotImplementedException();
		}

		public override ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotImplementedException();
		}

		public override ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotImplementedException();
		}

		public override ProfileInfoCollection GetAllProfiles(ProfileAuthenticationOption authenticationOption, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotImplementedException();
		}

		public override int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
		{
			throw new NotImplementedException();
		}

		public override string ApplicationName
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}
	}
}