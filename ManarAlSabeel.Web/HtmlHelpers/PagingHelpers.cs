using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ManarAlSabeel.Web.Models.HtmlHelpers
{
	public static class PagingHelpers
	{
		public static MvcHtmlString PageLinks(this HtmlHelper html,
		PagingInfo pagingInfo,
		Func<int, string> pageUrl)
		{
			StringBuilder result = new StringBuilder();
			for (int i = 1; i <= pagingInfo.TotalPages; i++)
			{
				TagBuilder iTag = new TagBuilder("li");

				TagBuilder ahrefTag = new TagBuilder("a"); // Construct an <a> tag
				ahrefTag.MergeAttribute("href", pageUrl(i));
				ahrefTag.InnerHtml = i.ToString();
				
				if (i == pagingInfo.CurrentPage)
					iTag.AddCssClass("active");

				iTag.InnerHtml = ahrefTag.ToString();
				result.Append(iTag.ToString());
			}
			return MvcHtmlString.Create(result.ToString());
		}
	}
}