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
using ManarAlSabeel.Web.Models;

namespace ManarAlSabeel.Web.Controllers
{
	[ForbiddenRedirectAuthorizeAttribute]
    public class HomeController : Controller
    {
		private ICenterRepository dbRepository;
		public HomeController(ICenterRepository repo)
		{
			dbRepository = repo;
		}

		public ViewResult Index()
		{
			Semester current = dbRepository.GetAllSemesters().ToList().FirstOrDefault(x => x.IsTheCurrent);
			IEnumerable<IGrouping<ExamType, Exam>> examsGroups = null;
			if (current != null)
			{
				examsGroups = dbRepository.GetAllExams()
					.Where(exam => exam.RegisteredStudent.Class.Semester.ID == current.ID)
					.ToList().GroupBy(exam => exam.Type);
			}

			return View(new HomeDashboardViewModel { Semester = current, ExamsGroup = examsGroups });
		}
    }
}
