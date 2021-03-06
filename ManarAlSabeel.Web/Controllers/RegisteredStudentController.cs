﻿using ManarAlSabeel.Domain.Abstract;
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

		public ViewResult List(int? semesterId, int page = 1)
		{
			PagingInfo pagingInfo = new PagingInfo
			{
				CurrentPage = page,
				ItemsPerPage = PageSize,
				TotalItems = dbRepository.GetAllClasses().Count()
			};
			RegisteredStudentsListViewModel model = new RegisteredStudentsListViewModel();
			IQueryable<RegisteredStudent> students = null;
			if (semesterId.HasValue)
			{
				students = dbRepository.GetAllRegisteredStudents().Where(student => student.Class.Semester.ID == semesterId).Skip((page - 1) * PageSize).Take(PageSize);
				Semester semster = dbRepository.GetAllSemesters().Where(s => s.ID == semesterId.Value).FirstOrDefault();
				if (semster != null)
					model.SemesterName = semster.Name;
			}
			else
				students = dbRepository.GetAllRegisteredStudents().Where(student => student.ID == 0);

			model.RegisteredStudents = students;
			model.PagingInfo = pagingInfo;

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
				viewModel.StageID = registeredStudentEntity.Stage.ID;

				viewModel.ExamsCount = registeredStudentEntity.Exams.Count;
                viewModel.DisciplinaryActivitiesCount = registeredStudentEntity.DisciplinaryActivities.Count;
				viewModel.Classes = dbRepository.GetAllClasses();
				viewModel.Students = dbRepository.GetAllStudents();
				viewModel.Stages = dbRepository.GetAllStages();
			}

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Edit(RegisteredStudentEditViewModel registeredStudent)
		{
			bool newStudentRegistration = (registeredStudent.ID == 0);
			Class _class = dbRepository.GetAllClasses().FirstOrDefault(x => x.ID == registeredStudent.ClassID);
			if (newStudentRegistration)
			{
				if (_class != null)
				{
					bool regisredBefore = dbRepository.IsStudentInSemester(registeredStudent.StudentID, _class.Semester.ID);
					if (regisredBefore)
					{
						ModelState.AddModelError("StudentRegsiteredBefore", Messages.StudentRegisteredBefore);
					}
				}

			}

			if (ModelState.IsValid)
			{
				RegisteredStudent registeredStudentEntity = new RegisteredStudent();
				registeredStudentEntity.ID = registeredStudent.ID;
				registeredStudentEntity.Class = new Class { ID = registeredStudent.ClassID };
				registeredStudentEntity.Stage = new Stage { ID = registeredStudent.StageID };
				registeredStudentEntity.Student = new Student { ID = registeredStudent.StudentID };

				registeredStudentEntity.Branch = new Branch { ID = Helpers.GetProfileBranch().ID };
				registeredStudentEntity.Sex = Helpers.GetProfileSex().Value;

				dbRepository.SaveRegisteredStudent(registeredStudentEntity);
				TempData["message"] = newStudentRegistration ? Messages.StudentRegisteredSuccesfully : Messages.StudentRegistrationEditedSuccesfully;

				return RedirectToAction("List", new { semesterId = _class.Semester.ID });
			}
			else
			{
				registeredStudent.Classes = dbRepository.GetAllClasses();
				registeredStudent.Students = dbRepository.GetAllStudents();
				registeredStudent.Stages = dbRepository.GetAllStages();
				return View(registeredStudent);
			}
		}

		public ViewResult Create()
		{
			RegisteredStudentEditViewModel viewModel = new RegisteredStudentEditViewModel();
			viewModel.Classes = dbRepository.GetAllClasses();
			viewModel.Students = dbRepository.GetAllStudents();
			viewModel.Stages = dbRepository.GetAllStages();

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
