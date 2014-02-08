using ManarAlSabeel.Domain.Abstract;
using ManarAlSabeel.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
			return View();
		}
    }
}
