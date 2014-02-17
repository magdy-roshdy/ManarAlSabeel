using ManarAlSabeel.Domain.Abstract;
using ManarAlSabeel.Domain.Entities;
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
    public class StudentGuardianController : Controller
    {
		private int PageSize = 25;
		private ICenterRepository dbRepository;
		public StudentGuardianController(ICenterRepository repo)
		{
			dbRepository = repo;
		}

        public ActionResult List(int page = 1)
        {
			PagingInfo pagingInfo = new PagingInfo
			{
				CurrentPage = page,
				ItemsPerPage = PageSize,
				TotalItems = dbRepository.GetAllStudents().Count()
			};

			IQueryable<StudentGuardian> studentGuardians = dbRepository.GetAllStudentGuardians().Skip((page - 1) * PageSize)
				.Take(PageSize);

			StudentGuardiansListViewModel model = new StudentGuardiansListViewModel
			{
				Guardians = studentGuardians, PagingInfo = pagingInfo
			};
			return View(model);
        }

		public ViewResult Edit(int id)
		{
			StudentGuardian student = dbRepository.GetAllStudentGuardians().FirstOrDefault<StudentGuardian>(x => x.ID == id);
			return View(student);
		}

		[HttpPost]
		public ActionResult Edit(StudentGuardian studentGuardian)
		{
			if (ModelState.IsValid)
			{
				//enforce profile values over form values
				studentGuardian.Branch.ID = ((Branch)HttpContext.Profile["BranchFilter"]).ID;

				dbRepository.SaveStudentGuardian(studentGuardian);
				return RedirectToAction("List");
			}
			else
			{
				return View(studentGuardian);
			}
		}

		public ViewResult Create()
		{
			return View("Edit", new StudentGuardian());
		}

		[HttpPost]
		public ActionResult Delete(int guardianId)
		{
			bool result = dbRepository.DeleteStudentGuardian(guardianId);

			return RedirectToAction("List");
		}
    }
}
