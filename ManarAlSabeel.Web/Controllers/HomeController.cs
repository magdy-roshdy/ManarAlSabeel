using ManarAlSabeel.Domain.Abstract;
using ManarAlSabeel.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

namespace ManarAlSabeel.Web.Controllers
{
	[Authorize]
    public class HomeController : Controller
    {
		private ICenterRepository repository;
		public HomeController(ICenterRepository repo)
		{
			repository = repo;
		}

		[ForbiddenRedirectAuthorizeAttribute]
		public ViewResult Index()
		{
			//TODO
			//switch to female culture in Females section based on Profile parameter
			//Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar-LB");
			return View();
		}
    }
}
