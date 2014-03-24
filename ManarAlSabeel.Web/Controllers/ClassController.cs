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
	public class ClassController : Controller
	{
		private int PageSize = 25;
		private ICenterRepository dbRepository;
		public ClassController(ICenterRepository repo)
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

			IQueryable<Class> classes =
				dbRepository.GetAllClasses().Skip((page - 1) * PageSize).Take(PageSize);
			ClassesListViewModel model = new ClassesListViewModel { Classes = classes, PagingInfo = pagingInfo };

			return View(model);
		}

		public ViewResult Edit(int id)
		{
			ClassEditViewModel viewModel = null;

			Class aClass = dbRepository.GetAllClasses().FirstOrDefault<Class>(x => x.ID == id);
			if(aClass != null)
			{
				viewModel = new ClassEditViewModel();

				viewModel.ClassID = aClass.ID;
				viewModel.ClassName = aClass.Name;
				viewModel.Sex = aClass.Sex;
				viewModel.TeachingPeriod = aClass.TeachingPeriod;
				
				viewModel.TeacherID = aClass.Teacher.ID;
				viewModel.TeacherName = aClass.Teacher.Name;

				viewModel.SemesterID = aClass.Semester.ID;
				viewModel.SemesterName = aClass.Semester.Name;

				viewModel.BranchID = aClass.Branch.ID;
				viewModel.BranchName = aClass.Branch.Name;

				viewModel.Semesters = dbRepository.GetAllSemesters();
				viewModel.Teachers = dbRepository.GetAllTeachers();
			}

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Edit(ClassEditViewModel aClass)
		{
			if (ModelState.IsValid)
			{
				bool newsClass = (aClass.ClassID == 0);
				
				Class classEntity = new Class();
				classEntity.ID = aClass.ClassID;
				classEntity.Name = aClass.ClassName;
				classEntity.Teacher = new Teacher { ID = aClass.TeacherID };
				classEntity.Semester = new Semester { ID = aClass.SemesterID };
				classEntity.TeachingPeriod = aClass.TeachingPeriod;

				classEntity.Branch = new Branch { ID = Helpers.GetProfileBranch().ID };
				classEntity.Sex = Helpers.GetProfileSex().Value;

				dbRepository.SaveClass(classEntity);
				TempData["message"] = newsClass ? Messages.ClassCreatedSuccessfully : Messages.EditedClassInfoSuccessful;

				return RedirectToAction("List");
			}
			else
			{
				return View(aClass);
			}
		}

		public ViewResult Create()
		{
			return
				View("Edit", new ClassEditViewModel
								{
									Teachers = dbRepository.GetAllTeachers(),
									Semesters = dbRepository.GetAllSemesters(),
									Sex = Helpers.GetProfileSex().Value
								}
					);
		}

		[HttpPost]
		public ActionResult Delete(int classId)
		{
			bool result = dbRepository.DeleteClass(classId);
			TempData["message"] = Messages.ClassDeletedSuccessfully;

			return RedirectToAction("List");
		}
    }
}
