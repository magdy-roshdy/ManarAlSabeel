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
using ManarAlSabeel.Domain.Entities;

namespace ManarAlSabeel.Web.Controllers
{
	[Authorize]
    public class HomeController : Controller
    {
		private ICenterRepository dbRepository;
		public HomeController(ICenterRepository repo)
		{
			dbRepository = repo;
		}

		[ForbiddenRedirectAuthorizeAttribute]
		public ViewResult Index()
		{
			Semester current = dbRepository.GetAllSemesters().ToList().FirstOrDefault(x => x.IsTheCurrent);
			return View(current);
		}
    }
}
