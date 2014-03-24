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
			TeacherEditViewModel teacherViewModel = null;
			Teacher teacherEntity = dbRepository.GetAllTeachers().FirstOrDefault<Teacher>(x => x.ID == id);
			if (teacherEntity != null)
			{
				teacherViewModel = new TeacherEditViewModel();
				teacherViewModel.ID = teacherEntity.ID;
				teacherViewModel.AmountOfMemorization = teacherEntity.AmountOfMemorization;
				teacherViewModel.BirthDate = teacherEntity.BirthDate;

				teacherViewModel.BirthPlaceID = teacherEntity.BirthPlace.ID;
				teacherViewModel.BirthPlaceName = teacherEntity.BirthPlace.Name;
				
				teacherViewModel.BranchID = teacherEntity.Branch.ID;
				teacherViewModel.BranchName = teacherEntity.Branch.Name;

				teacherViewModel.Email = teacherEntity.Email;
				teacherViewModel.HomeNumber = teacherEntity.HomeNumber;
				teacherViewModel.IsSupervisor = teacherEntity.IsSupervisor;
				teacherViewModel.MaritalStatus = teacherEntity.MaritalStatus;
				if (teacherEntity.MarriageDate.HasValue)
					teacherViewModel.MarriageDate = teacherEntity.MarriageDate;
				else
					teacherViewModel.MarriageDate = null;
				teacherViewModel.MobileNumber = teacherEntity.MobileNumber;
				teacherViewModel.Name = teacherEntity.Name;

				teacherViewModel.NationalityID = teacherEntity.Nationality.ID;
				teacherViewModel.NationalityName = teacherEntity.Nationality.Name;

				teacherViewModel.Profession = teacherEntity.Profession;
				teacherViewModel.ReligiousIdeology = teacherEntity.ReligiousIdeology;
				teacherViewModel.Sex = teacherEntity.Sex;
				teacherViewModel.Status = teacherEntity.Status;

				teacherViewModel.Countries = dbRepository.GetAllCountries();
			}

			return View(teacherViewModel);
		}

		[HttpPost]
		public ActionResult Edit(TeacherEditViewModel teacherViewModel)
		{
			if (ModelState.IsValid)
			{
				Teacher teacherEntity = new Teacher();
				//enforce profile values over form values
				teacherEntity.Sex = Helpers.GetProfileSex().Value;
				teacherEntity.Branch = new Branch();
				teacherEntity.Branch.ID = Helpers.GetProfileBranch().ID;

				teacherEntity.ID = teacherViewModel.ID;
				teacherEntity.AmountOfMemorization = teacherViewModel.AmountOfMemorization;
				teacherEntity.BirthDate = teacherViewModel.BirthDate;

				teacherEntity.BirthPlace = new Country();
				teacherEntity.BirthPlace.ID = teacherViewModel.BirthPlaceID;

				teacherEntity.Email = teacherViewModel.Email;
				teacherEntity.HomeNumber = teacherViewModel.HomeNumber;
				teacherEntity.IsSupervisor = teacherViewModel.IsSupervisor;
				teacherEntity.MaritalStatus = teacherViewModel.MaritalStatus;
				teacherEntity.MarriageDate = teacherViewModel.MarriageDate;
				teacherEntity.MobileNumber = teacherViewModel.MobileNumber;
				teacherEntity.Name = teacherViewModel.Name;

				teacherEntity.Nationality = new Country();
				teacherEntity.Nationality.ID = teacherViewModel.NationalityID;

				teacherEntity.Profession = teacherViewModel.Profession;
				teacherEntity.ReligiousIdeology = teacherViewModel.ReligiousIdeology;
				teacherEntity.Status = teacherViewModel.Status;
				
				dbRepository.SaveTeacher(teacherEntity);

				bool newTeacher = (teacherViewModel.ID == 0);
				TempData["message"] = newTeacher ? Messages.TeacherCreatedSuccessfully : Messages.EditTeacherSuccessful;

				return RedirectToAction("List");
			}
			else
			{
				teacherViewModel.Countries = dbRepository.GetAllCountries();
				return View(teacherViewModel);
			}
		}

		public ViewResult Create()
		{
			return View("Edit", new Models.TeacherEditViewModel
			{
				BirthDate = DateTime.Now.Subtract(new TimeSpan(365 * 30, 0, 0, 0)),
				Sex = Helpers.GetProfileSex().Value,
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
