using ManarAlSabeel.Domain.Abstract;
using ManarAlSabeel.Domain.Entities;
using ManarAlSabeel.Resources;
using ManarAlSabeel.Web.Heplers;
using ManarAlSabeel.Web.Infrastructure;
using ManarAlSabeel.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManarAlSabeel.Web.Controllers
{
	[ForbiddenRedirectAuthorizeAttribute]
    public class StudentController : Controller
    {
		private int PageSize = 25;
		private ICenterRepository dbRepository;
		public StudentController(ICenterRepository repo)
		{
			dbRepository = repo;
		}

		public ViewResult List(int page = 1, int guardianId = 0)
        {
			PagingInfo pagingInfo = new PagingInfo
			{
				CurrentPage = page,
				ItemsPerPage = PageSize,
				TotalItems = (guardianId > 0) ?
					dbRepository.GetAllStudents().Where(x => x.Guardian.ID == guardianId).Count()
					:
					dbRepository.GetAllStudents().Count()
			};
			IQueryable<Student> students;
			students = (guardianId > 0) ?
				dbRepository.GetAllStudents().Where(x => x.Guardian.ID == guardianId).Skip((page - 1) * PageSize).Take(PageSize)
				:
				dbRepository.GetAllStudents().Skip((page - 1) * PageSize).Take(PageSize)
				;

			StudentsListViewModel model = new StudentsListViewModel { Students = students, PagingInfo = pagingInfo };
			return View(model);
        }

		public ViewResult Edit(int id)
		{
			Student studentEntity = dbRepository.GetAllStudents().FirstOrDefault<Student>(x => x.ID == id);
			StudentEditViewModel studentViewModel = null;

			if (studentEntity != null)
			{
				studentViewModel = new StudentEditViewModel();

				studentViewModel.ID = studentEntity.ID;
				studentViewModel.Name = studentEntity.Name;
				studentViewModel.BirthDate = studentEntity.BirthDate;
				studentViewModel.EducationStage = studentEntity.EducationStage;
				studentViewModel.ExpectedQuraanFinishTime = studentEntity.ExpectedQuraanFinishTime;
				studentViewModel.HowKnewTheCenter = studentEntity.HowKnewTheCenter;
				studentViewModel.IsInTransportations = studentEntity.IsInTransportations;
				studentViewModel.LastEducationDegree = studentEntity.LastEducationDegree;
				studentViewModel.PersonalPhotoPath = studentEntity.PersonalPhotoPath;
				studentViewModel.SchoolClass = studentEntity.SchoolClass;
				studentViewModel.SchoolName = studentEntity.SchoolName;
				studentViewModel.Sex = studentEntity.Sex;
				studentViewModel.Status = studentEntity.Status;
				studentViewModel.ProfilePhotoName = studentEntity.ProfilePhotoName;

				studentViewModel.OriginalNationalityID = studentEntity.OriginalNationality.ID;
				studentViewModel.OriginalNationalityName = studentEntity.OriginalNationality.Name;

				if (studentEntity.AcquiredNationality != null && studentEntity.AcquiredNationality.ID != 0)
				{
					studentViewModel.AcquiredNationalityID = studentEntity.AcquiredNationality.ID;
					studentViewModel.AcquiredNationalityName = studentEntity.AcquiredNationality.Name;
				}

				studentViewModel.BranchID = studentEntity.Branch.ID;
				studentViewModel.BranchName = studentEntity.Branch.Name;

				studentViewModel.GuardianID = studentEntity.Guardian.ID;
				studentViewModel.GuardianName = studentEntity.Guardian.Name;

				studentViewModel.Countries = dbRepository.GetAllCountries();
				studentViewModel.Guardians = dbRepository.GetAllStudentGuardians();

				if (studentEntity.AdmissionInterview != null)
				{
					studentViewModel.AdmissionInterviewID = studentEntity.AdmissionInterview.ID;
				}
			}

			return View(studentViewModel);
		}

		[HttpPost]
		public ActionResult Edit(StudentEditViewModel studentViewModel)
		{
			if (ModelState.IsValid)
			{
				bool newsStudent = (studentViewModel.ID == 0);

				Student studentEntity = new Student();
				//enforce profile values over form values
				studentEntity.Sex = Helpers.GetProfileSex().Value;
				studentEntity.Branch = new Branch();
				studentEntity.Branch.ID = Helpers.GetProfileBranch().ID;

				studentEntity.ID = studentViewModel.ID;
				
				studentEntity.AcquiredNationality = new Country();
				studentEntity.AcquiredNationality.ID = studentViewModel.AcquiredNationalityID;

				studentEntity.OriginalNationality = new Country();
				studentEntity.OriginalNationality.ID = studentViewModel.OriginalNationalityID;

				studentEntity.Guardian = new StudentGuardian();
				studentEntity.Guardian.ID = studentViewModel.GuardianID;

				studentEntity.BirthDate = studentViewModel.BirthDate;
				studentEntity.EducationStage = studentViewModel.EducationStage;
				studentEntity.ExpectedQuraanFinishTime = studentViewModel.ExpectedQuraanFinishTime;
				studentEntity.HowKnewTheCenter = studentViewModel.HowKnewTheCenter;
				studentEntity.IsInTransportations = studentViewModel.IsInTransportations;
				studentEntity.LastEducationDegree = studentViewModel.LastEducationDegree;
				studentEntity.Name = studentViewModel.Name;
				studentEntity.PersonalPhotoPath = studentViewModel.PersonalPhotoPath;
				studentEntity.SchoolClass = studentViewModel.SchoolClass;
				studentEntity.SchoolName = studentViewModel.SchoolName;
				studentEntity.Status = studentViewModel.Status;

				if (newsStudent)
					studentEntity.AddedOn = DateTime.Now;

				dbRepository.SaveStudent(studentEntity);

				//save profile photo
				if (Request != null)
				{
					HttpPostedFileBase photoFile = Request.Files["studentPhoto"];
					if(photoFile.ContentLength > 0)
					{
						string fileName = string.Format("student_{0}{1}", studentEntity.ID, Path.GetExtension(photoFile.FileName));
						var savePath = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["StudentsImagesPath"]),
							fileName);
						photoFile.SaveAs(savePath);

						studentEntity.ProfilePhotoName = fileName;
						dbRepository.SaveStudent(studentEntity);
					}
				}

				TempData["message"] = newsStudent ? Messages.StudentCreatedSuccessfully : Messages.EditStudentSuccessful;

				if (studentViewModel.AddAdmissionInterviewNow)
					return RedirectToAction("Create", "AdmissionInterview", new { studentId = studentEntity.ID });
				else
					return RedirectToAction("List");
			}
			else
			{
				studentViewModel.Countries = dbRepository.GetAllCountries();
				studentViewModel.Guardians = dbRepository.GetAllStudentGuardians();

				return View(studentViewModel);
			}
		}

		public ViewResult Create()
		{
			return View("Edit", new Models.StudentEditViewModel
			{
				BirthDate = DateTime.Now.Subtract(new TimeSpan(365 * 15, 0, 0, 0)),
				Sex = Helpers.GetProfileSex().Value,
				Countries = dbRepository.GetAllCountries(),
				Guardians = dbRepository.GetAllStudentGuardians()
			});
		}

		[HttpPost]
		public ActionResult Delete(int studentId)
		{
			bool result = dbRepository.DeleteStudent(studentId);
			TempData["message"] = Messages.StudentDeletedSuccessfully;

			return RedirectToAction("List");
		}
    }
}
