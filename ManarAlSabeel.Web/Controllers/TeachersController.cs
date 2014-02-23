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
    public class TeachersController : Controller
    {
		private ICenterRepository dbRepository;
		private int PageSize = 25;

		public TeachersController(ICenterRepository repo)
		{
			dbRepository = repo;
		}

		public ViewResult List(int page = 1)
		{
			PagingInfo pagingInfo = new PagingInfo
			{
				CurrentPage = page,
				ItemsPerPage = PageSize,
				TotalItems = dbRepository.GetAllTeachers().Count()
			};
			IQueryable<Teacher> teachers = dbRepository.GetAllTeachers().Skip((page - 1) * PageSize)
				.Take(PageSize);

			TeachersListViewModel model = new TeachersListViewModel { Teachers = teachers, PagingInfo = pagingInfo };
			return View(model);
		}

		public ViewResult Edit(int id)
		{
			Teacher teacher = dbRepository.GetAllTeachers().FirstOrDefault<Teacher>(x => x.ID == id);
			IQueryable<Country> countries = dbRepository.GetAllCountries();

			return View(new Models.EditTeacherViewModel { Teacher = teacher, Countries = countries});
		}

		[HttpPost]
		public ActionResult Edit(Teacher teacher)
		{
			if (ModelState.IsValid)
			{
				//enforce profile values over form values
				teacher.Sex = (Sex)HttpContext.Profile["SexFilter"];
				teacher.Branch.ID = ((Branch)HttpContext.Profile["BranchFilter"]).ID;

				bool newTeacher = (teacher.ID == 0);
				dbRepository.SaveTeacher(teacher);
				TempData["message"] = newTeacher ? Messages.TeacherCreatedSuccessfully : Messages.EditTeacherSuccessful;

				return RedirectToAction("List");
			}
			else
			{
				IQueryable<Country> countries = dbRepository.GetAllCountries();
				IQueryable<StudentGuardian> guardians = dbRepository.GetAllStudentGuardians();

				return View(
						new Models.EditTeacherViewModel { Teacher = teacher, Countries = countries }
					);
			}
		}

		public ViewResult Create()
		{
			return View("Edit", new Models.EditTeacherViewModel
			{
				Teacher = new Teacher
				{
					BirthDate = DateTime.Now.Subtract(new TimeSpan(365 * 30, 0, 0, 0)),
					Sex = (Sex)HttpContext.Profile["SexFilter"]
				},
				Countries = dbRepository.GetAllCountries(),
			});
		}

		[HttpPost]
		public ActionResult Delete(int teacherId, string returnUrl)
		{
			bool result = dbRepository.DeleteTeacher(teacherId);
			TempData["message"] = Messages.TeacherDeletedSuccessfully;
			return RedirectToAction("List");
		}
    }
}
