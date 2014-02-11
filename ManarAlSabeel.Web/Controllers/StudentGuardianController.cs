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
    public class StudentGuardianController : Controller
    {
		private ICenterRepository dbRepository;
		public StudentGuardianController(ICenterRepository repo)
		{
			dbRepository = repo;
		}

        public ActionResult List()
        {
			return View(dbRepository.GetAllStudentGuardians());
        }

		public ViewResult Edit(int id)
		{
			StudentGuardian student = dbRepository.GetAllStudentGuardians().FirstOrDefault<StudentGuardian>(x => x.ID == id);
			return View(student);
		}

		[HttpPost]
		public ActionResult Edit(StudentGuardian studentGuardian, int id)
		{
			if (ModelState.IsValid)
			{
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
