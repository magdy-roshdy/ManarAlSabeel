using ManarAlSabeel.Domain.Abstract;
using ManarAlSabeel.Domain.Entities;
using ManarAlSabeel.Resources;
using ManarAlSabeel.Web.Infrastructure;
using ManarAlSabeel.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManarAlSabeel.Web.Controllers
{
	[ForbiddenRedirectAuthorizeAttribute]
    public class SemesterController : Controller
    {
        private int PageSize = 25;
		private ICenterRepository dbRepository;
		public SemesterController(ICenterRepository repo)
		{
			dbRepository = repo;
		}

		public ViewResult List(int page = 1)
		{
			PagingInfo pagingInfo = new PagingInfo
			{
				CurrentPage = page,
				ItemsPerPage = PageSize,
				TotalItems = dbRepository.GetAllSemesters().Count()
			};
			IQueryable<Semester> semesters = dbRepository.GetAllSemesters().Skip((page - 1) * PageSize).Take(PageSize);
			SemestersListViewModel model = new SemestersListViewModel { Semesters = semesters, PagingInfo = pagingInfo };

			return View(model);
		}

		public ViewResult Edit(int id)
		{
			Semester semester = dbRepository.GetAllSemesters().FirstOrDefault<Semester>(x => x.ID == id);
			return View(semester);
		}

		[HttpPost]
		public ActionResult Edit(Semester semester)
		{
			if (ModelState.IsValid)
			{
				//enforce profile values over form values
				semester.Branch.ID = ((Branch)HttpContext.Profile["BranchFilter"]).ID;

				bool newsSemester = (semester.ID == 0);
				dbRepository.SaveSemester(semester);
				TempData["message"] = newsSemester ? Messages.SemesterCreatedSuccessfully : Messages.EditedSemesterInfoSuccessful;

				return RedirectToAction("List");
			}
			else
			{
				return View(semester);
			}
		}

		public ViewResult Create()
		{
			return View("Edit", new Semester { StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(6 * 30) });
		}

		[HttpPost]
		public ActionResult Delete(int semesterId)
		{
			bool result = dbRepository.DeleteSemeter(semesterId);
			TempData["message"] = Messages.SemesterDeletedSuccessfully;

			return RedirectToAction("List");
		}
    }
}
