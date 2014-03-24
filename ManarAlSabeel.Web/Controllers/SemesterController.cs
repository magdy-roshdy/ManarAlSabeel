using ManarAlSabeel.Domain.Abstract;
using ManarAlSabeel.Domain.Entities;
using ManarAlSabeel.Resources;
using ManarAlSabeel.Web.Heplers;
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
			SemesterEditViewModel semesterViewModel = null;
			Semester semesterEntity = dbRepository.GetAllSemesters().FirstOrDefault<Semester>(x => x.ID == id);
			if(semesterEntity != null)
			{
				semesterViewModel = new SemesterEditViewModel();
				semesterViewModel.ID = semesterEntity.ID;
				semesterViewModel.Name = semesterEntity.Name;
				semesterViewModel.StartDate = semesterEntity.StartDate;
				semesterViewModel.EndDate = semesterEntity.EndDate;
			}

			return View(semesterViewModel);
		}

		[HttpPost]
		public ActionResult Edit(SemesterEditViewModel semesterViewModel)
		{
			if (ModelState.IsValid)
			{
				Semester semesterEntity = new Semester();
				//enforce profile values over form values
				semesterEntity.Branch = new Branch();
				semesterEntity.Branch.ID = Helpers.GetProfileBranch().ID;

				semesterEntity.Name = semesterViewModel.Name;
				semesterEntity.StartDate = semesterViewModel.StartDate;
				semesterEntity.EndDate = semesterViewModel.EndDate;
				semesterEntity.ID = semesterViewModel.ID;

				dbRepository.SaveSemester(semesterEntity);

				bool newsSemester = (semesterViewModel.ID == 0);
				TempData["message"] = newsSemester ? Messages.SemesterCreatedSuccessfully : Messages.EditedSemesterInfoSuccessful;

				return RedirectToAction("List");
			}
			else
			{
				return View(semesterViewModel);
			}
		}

		public ViewResult Create()
		{
			return View("Edit", new SemesterEditViewModel { StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(6 * 30) });
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
