using ManarAlSabeel.Domain.Entities;
using ManarAlSabeel.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManarAlSabeel.Web.HtmlHeplers
{
	public static class Helpers
	{
		public static string GetPageTitle(string pageTitle)
		{
			return string.Format("{0} - {1}", StringTable.ManarAlSabeel, pageTitle);
		}

		public static string GetSexCaption(Sex sex)
		{
			return
				(sex == Sex.Male)
				?
				StringTable.Male
				:
				StringTable.Female;
		}
	}
}