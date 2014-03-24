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
    public class StudentGuardianController : Controller
    {
		private int PageSize = 25;
		private ICenterRepository dbRepository;
		public StudentGuardianController(ICenterRepository repo)
		{
			dbRepository = repo;
		}

        public ActionResult List(int page = 1)
        {
			PagingInfo pagingInfo = new PagingInfo
			{
				CurrentPage = page,
				ItemsPerPage = PageSize,
				TotalItems = dbRepository.GetAllStudents().Count()
			};

			IQueryable<StudentGuardian> studentGuardians = dbRepository.GetAllStudentGuardians().Skip((page - 1) * PageSize)
				.Take(PageSize);

			StudentGuardiansListViewModel model = new StudentGuardiansListViewModel
			{
				Guardians = studentGuardians, PagingInfo = pagingInfo
			};
			return View(model);
        }

		public ViewResult Edit(int id)
		{
			StudentGuardianEditViewModel studentViewModel = null;
			StudentGuardian studentEntity = dbRepository.GetAllStudentGuardians().FirstOrDefault<StudentGuardian>(x => x.ID == id);
			if (studentEntity != null)
			{
				studentViewModel = new StudentGuardianEditViewModel();
				studentViewModel.ID = studentEntity.ID;
				studentViewModel.Name = studentEntity.Name;
				studentViewModel.HomeAddress = studentEntity.HomeAddress;
				studentViewModel.HomePhone = studentEntity.HomePhone;
				studentViewModel.MobilePhone = studentEntity.MobilePhone;
				studentViewModel.OtherPhone = studentEntity.OtherPhone;
				studentViewModel.Sex = studentEntity.Sex;
				studentViewModel.Email = studentEntity.Email;

				studentViewModel.BranchID = studentEntity.Branch.ID;
				studentViewModel.BranchName = studentEntity.Branch.Name;
			}

			return View(studentViewModel);
		}

		[HttpPost]
		public ActionResult Edit(StudentGuardianEditViewModel studentGuardianViewModel)
		{
			if (ModelState.IsValid)
			{
				StudentGuardian studentGuardianEntity = new StudentGuardian();
				//enforce profile values over form values
				studentGuardianEntity.Branch = new Branch();
				studentGuardianEntity.Branch.ID = Helpers.GetProfileBranch().ID;

				studentGuardianEntity.ID = studentGuardianViewModel.ID;
				studentGuardianEntity.Name = studentGuardianViewModel.Name;
				studentGuardianEntity.Email = studentGuardianViewModel.Email;
				studentGuardianEntity.HomeAddress = studentGuardianViewModel.HomeAddress;
				studentGuardianEntity.HomePhone = studentGuardianViewModel.HomePhone;
				studentGuardianEntity.MobilePhone = studentGuardianViewModel.MobilePhone;
				studentGuardianEntity.OtherPhone = studentGuardianViewModel.OtherPhone;
				studentGuardianEntity.Sex = studentGuardianViewModel.Sex;


				dbRepository.SaveStudentGuardian(studentGuardianEntity);

				bool newsGuardian = (studentGuardianViewModel.ID == 0);
				TempData["message"] = newsGuardian ? Messages.GuardianCreatedSuccessfully : Messages.EditGuardianSuccessful;

				return RedirectToAction("List");
			}
			else
			{
				return View(studentGuardianViewModel);
			}
		}

		public ViewResult Create()
		{
			return View("Edit", new StudentGuardianEditViewModel());
		}

		[HttpPost]
		public ActionResult Delete(int guardianId)
		{
			bool result = dbRepository.DeleteStudentGuardian(guardianId);
			TempData["message"] = Messages.GuardianDeletedSuccessfully;

			return RedirectToAction("List");
		}
    }
}
