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

		public ViewResult List(int? registeredStudentId)
		{
			IQueryable<Exam> exams = null;
			if (registeredStudentId.HasValue)
				exams = dbRepository.GetAllExams().Where(exam => exam.RegisteredStudent.ID == registeredStudentId.Value).OrderBy(exam => exam.Date);
			else
				exams = dbRepository.GetAllExams().Where(exam => exam.ID == 0);

			return View(new ExamsListViewModel { Exams = exams });
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
			ExamEditViewModel examEditViewModel = null;
			Exam examEntity = dbRepository.GetAllExams().FirstOrDefault<Exam>(x => x.ID == id);
			if (examEntity != null)
			{
				examEditViewModel = new ExamEditViewModel();
				examEditViewModel.ID = examEntity.ID;
				examEditViewModel.RegistredStudentID = examEntity.RegisteredStudent.ID;
				examEditViewModel.SupervisorID = examEntity.Supervisor.ID;
				examEditViewModel.ExternalSupervisorID = (examEntity.ExternalSupervisor != null) ? examEntity.ExternalSupervisor.ID : 0;
				examEditViewModel.Date = examEntity.Date;
				examEditViewModel.Comments = examEntity.Comments;
				examEditViewModel.BonusPoints = examEntity.BonusPoints;

				examEditViewModel.Teachers = dbRepository.GetAllTeachers();
				examEditViewModel.ExternalSupervisors = dbRepository.GetAllExternalSupervisors();
				examEditViewModel.ExamTypes = dbRepository.GetAllExamTypes();
				examEditViewModel.ExamGrades = dbRepository.GetAllExamGrades();
			}

			return View(examEditViewModel);
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
				TempData["message"] = newsExam ? Messages.ExamAdded : Messages.ExamEditedSuccessfully;

				return RedirectToAction("Edit", "RegisteredStudent", new { id = exam.RegistredStudentID });
			}
			else
			{
				return View(exam);
			}
		}
    }
}
