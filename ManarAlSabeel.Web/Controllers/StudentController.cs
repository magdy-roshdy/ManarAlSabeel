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
			return View(new Models.EditUserViewModel { Student = student, Countries = countries, Guardians = guardians });
		}

		[HttpPost]
		public ActionResult Edit(Student student, int id)
		{
			if (ModelState.IsValid)
			{
				dbRepository.SaveStudent(student);
				
				return RedirectToAction("List");
			}
			else
			{
				return View(student);
			}
		}

		public ViewResult Create()
		{
			return View("Edit", new Models.EditUserViewModel { Student = new Student(),
				Countries = dbRepository.GetAllCountries(), Guardians=dbRepository.GetAllStudentGuardians() });
		}

		[HttpPost]
		public ActionResult Delete(int studentId)
		{
			bool result = dbRepository.DeleteStudent(studentId);

			return RedirectToAction("List");
		}
    }
}
