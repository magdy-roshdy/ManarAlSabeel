using ManarAlSabeel.Domain.Abstract;
using ManarAlSabeel.Domain.Entities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Profile;

namespace ManarAlSabeel.Web.Infrastructure
{
	public class SystemAdminsProfileProvider : ProfileProvider
	{
		[Inject]
		public ICenterRepository DBRepository { get; set; }

		private IDictionary<string, IDictionary<string, object>> profilePropertiesCache = new Dictionary<string, IDictionary<string, object>>();
		public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
		{
			SettingsPropertyValueCollection result = new SettingsPropertyValueCollection();

			string userName = null;
			if(context.ContainsKey("UserName"))
			{
				userName = context["UserName"] as string;
			}

			bool? isAuthenticated = null;
			if (context.ContainsKey("IsAuthenticated"))
			{
				isAuthenticated = context["IsAuthenticated"] as bool?;
			}

			if (!string.IsNullOrEmpty(userName) && isAuthenticated.Value)
			{
				IDictionary<string, object> userData;
				bool dataExistInCache = profilePropertiesCache.TryGetValue(userName, out userData);
				if (!dataExistInCache)
				{
					//very critical!
					//--------------
					//profile provider rely on DB to person profile, and DB session rely on profile provider to load filters values
					//if i will make a DB call from the profile provider i have to switch filter off before the calla and set it back off after
					DBRepository.SetFilterIgnore(true);
					SystemAdmin admin = DBRepository.GetSystemAdminByEmail(userName);
					DBRepository.SetFilterIgnore(false);
					
					Dictionary<string, object> profileProperties = new Dictionary<string, object>();
					profileProperties.Add("SystemAdmin", admin);
					profilePropertiesCache.Add(admin.Email, profileProperties);

					dataExistInCache = profilePropertiesCache.TryGetValue(userName, out userData);
				}

				if(dataExistInCache)
				{
					foreach (SettingsProperty prop in collection)
					{
						SettingsPropertyValue spv = new SettingsPropertyValue(prop);
						spv.PropertyValue = userData[prop.Name];
						result.Add(spv);
					}
				}
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