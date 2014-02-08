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
			return View(student);
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
			return View("Edit", new Student());
		}
    }
}
