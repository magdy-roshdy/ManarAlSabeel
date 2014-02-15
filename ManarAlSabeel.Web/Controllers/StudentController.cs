using ManarAlSabeel.Domain.Abstract;
using ManarAlSabeel.Domain.Entities;
using ManarAlSabeel.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManarAlSabeel.Web.Controllers
{
	[ForbiddenRedirectAuthorizeAttribute]
    public class StudentController : Controller
    {
		private ICenterRepository dbRepository;
		public StudentController(ICenterRepository repo)
		{
			dbRepository = repo;
		}

		public ViewResult List()
        {
			return View(dbRepository.GetAllStudents());
        }

		public ViewResult Edit(int id)
		{
			Student student = dbRepository.GetAllStudents().FirstOrDefault<Student>(x => x.ID == id);
			IQueryable<Country> countries = dbRepository.GetAllCountries();
			IQueryable<StudentGuardian> guardians = dbRepository.GetAllStudentGuardians();

			return View(new Models.EditStudentViewModel { Student = student, Countries = countries, Guardians = guardians });
		}

		[HttpPost]
		public ActionResult Edit(Student student)
		{
			if (ModelState.IsValid)
			{
				//enforce profile values over form values
				student.Sex = (Sex)HttpContext.Profile["SexFilter"];
				student.Branch.ID = ((Branch)HttpContext.Profile["BranchFilter"]).ID;

				dbRepository.SaveStudent(student);
				
				return RedirectToAction("List");
			}
			else
			{
				IQueryable<Country> countries = dbRepository.GetAllCountries();
				IQueryable<StudentGuardian> guardians = dbRepository.GetAllStudentGuardians();

				return View(
						new Models.EditStudentViewModel { Student = student, Countries = countries, Guardians = guardians }
					);
			}
		}

		public ViewResult Create()
		{
			return View("Edit", new Models.EditStudentViewModel
			{
				Student = new Student { BirthDate = DateTime.Now.Subtract(new TimeSpan(365 * 15, 0, 0, 0)),
					Sex = (Sex)HttpContext.Profile["SexFilter"] },
				Countries = dbRepository.GetAllCountries(),
				Guardians = dbRepository.GetAllStudentGuardians()
			});
		}

		[HttpPost]
		public ActionResult Delete(int studentId)
		{
			bool result = dbRepository.DeleteStudent(studentId);

			return RedirectToAction("List");
		}
    }
}
