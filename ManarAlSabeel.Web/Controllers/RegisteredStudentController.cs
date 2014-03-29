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
    public class RegisteredStudentController : Controller
    {
		private int PageSize = 25;
		private ICenterRepository dbRepository;
		public RegisteredStudentController(ICenterRepository repo)
		{
			dbRepository = repo;
		}

		public ViewResult List(int page = 1)
		{
			PagingInfo pagingInfo = new PagingInfo
			{
				CurrentPage = page,
				ItemsPerPage = PageSize,
				TotalItems = dbRepository.GetAllClasses().Count()
			};

			IQueryable<RegisteredStudent> students =
				dbRepository.GetAllRegisteredStudents().Skip((page - 1) * PageSize).Take(PageSize);
			RegisteredStudentsListViewModel model = new RegisteredStudentsListViewModel { RegisteredStudents = students, PagingInfo = pagingInfo };

			return View(model);
		}

		public ViewResult Edit(int id)
		{
			RegisteredStudentEditViewModel viewModel = null;

			RegisteredStudent registeredStudentEntity = dbRepository.GetAllRegisteredStudents().FirstOrDefault<RegisteredStudent>(x => x.ID == id);
			if (registeredStudentEntity != null)
			{
				viewModel = new RegisteredStudentEditViewModel();

				viewModel.ID = registeredStudentEntity.ID;
				viewModel.ClassID = registeredStudentEntity.Class.ID;
				viewModel.StudentID = registeredStudentEntity.Student.ID;
				viewModel.TrackID = registeredStudentEntity.Track.ID;

				viewModel.Classes = dbRepository.GetAllClasses();
				viewModel.Students = dbRepository.GetAllStudents();
				viewModel.Tracks = dbRepository.GetAllTracks();
			}

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Edit(RegisteredStudentEditViewModel registeredStudent)
		{
			if (ModelState.IsValid)
			{
				bool newsClass = (registeredStudent.ID == 0);

				RegisteredStudent registeredStudentEntity = new RegisteredStudent();
				registeredStudentEntity.ID = registeredStudent.ID;
				registeredStudentEntity.Class = new Class { ID = registeredStudent.ClassID };
				registeredStudentEntity.Track = new Track { ID = registeredStudent.TrackID };
				registeredStudentEntity.Student = new Student { ID = registeredStudent.StudentID };

				registeredStudentEntity.Branch = new Branch { ID = Helpers.GetProfileBranch().ID };
				registeredStudentEntity.Sex = Helpers.GetProfileSex().Value;

				dbRepository.SaveRegisteredStudent(registeredStudentEntity);
				TempData["message"] = newsClass ? Messages.StudentRegisteredSuccesfully : Messages.StudentRegistrationEditedSuccesfully;

				return RedirectToAction("List");
			}
			else
			{
				return View(registeredStudent);
			}
		}

		public ViewResult Create()
		{
			RegisteredStudentEditViewModel viewModel = new RegisteredStudentEditViewModel();
			viewModel.Classes = dbRepository.GetAllClasses();
			viewModel.Students = dbRepository.GetAllStudents();
			viewModel.Tracks = dbRepository.GetAllTracks();

			return View("Edit", viewModel);
		}

		[HttpPost]
		public ActionResult Delete(int registeredStudentId)
		{
			bool result = dbRepository.DeleteRegisteredStudent(registeredStudentId);
			TempData["message"] = Messages.RegisteredStudentDeletedSuccessfully;

			return RedirectToAction("List");
		}
    }
}
