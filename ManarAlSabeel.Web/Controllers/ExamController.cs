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
    public class ExamController : Controller
    {
		private ICenterRepository dbRepository;
		public ExamController(ICenterRepository repo)
		{
			dbRepository = repo;
		}

		public ViewResult Create(int registeredStudentId)
		{
			ExamEditViewModel examEditViewModel = new ExamEditViewModel();
			examEditViewModel.Date = DateTime.Now;
			examEditViewModel.RegistredStudentID = registeredStudentId;

			examEditViewModel.Teachers = dbRepository.GetAllTeachers();
			examEditViewModel.ExternalSupervisors = dbRepository.GetAllExternalSupervisors();
			examEditViewModel.ExamTypes = dbRepository.GetAllExamTypes();
			examEditViewModel.ExamGrades = dbRepository.GetAllExamGrades();

			return View("Edit", examEditViewModel);
		}

		public ViewResult Edit(int id)
		{
			ExamEditViewModel examViewModel = null;
			Exam examEntity = dbRepository.GetAllExams().FirstOrDefault<Exam>(x => x.ID == id);
			if (examEntity != null)
			{
				examViewModel = new ExamEditViewModel();
				examViewModel.ID = examEntity.ID;
				examViewModel.RegistredStudentID = examEntity.RegisteredStudent.ID;
				examViewModel.SupervisorID = examEntity.Supervisor.ID;
				examViewModel.ExternalSupervisorID = (examEntity.ExternalSupervisor != null) ? examEntity.ExternalSupervisor.ID : 0;
				examViewModel.Date = examEntity.Date;
				examViewModel.Comments = examEntity.Comments;
				examViewModel.BonusPoints = examEntity.BonusPoints;
			}

			return View(examViewModel);
		}

		[HttpPost]
		public ActionResult Edit(ExamEditViewModel exam)
		{
			if (ModelState.IsValid)
			{
				bool newsExam = (exam.ID == 0);

				Exam examEntity = new Exam();
				examEntity.ID = exam.ID;
				examEntity.RegisteredStudent = new RegisteredStudent { ID = exam.RegistredStudentID };
				examEntity.Supervisor = new Teacher { ID = exam.SupervisorID };
				if (exam.ExternalSupervisorID.HasValue && exam.ExternalSupervisorID.Value > 0)
					examEntity.ExternalSupervisor = new ExternalSupervisor { ID = exam.ExternalSupervisorID.Value };
				else
					examEntity.ExternalSupervisor = null;
				examEntity.Grade = new ExamGrade { ID = exam.ExamGradeID };
				examEntity.Type  = new ExamType { ID = exam.ExamTypeID };
				examEntity.Comments = string.IsNullOrWhiteSpace(exam.Comments) ? null : exam.Comments;
				examEntity.BonusPoints = exam.BonusPoints;
				examEntity.Date = exam.Date;

				dbRepository.SaveExam(examEntity);
				TempData["message"] = Messages.ExamAdded;

				return RedirectToAction("List", "RegisteredStudent");
			}
			else
			{
				return View(exam);
			}
		}
    }
}
