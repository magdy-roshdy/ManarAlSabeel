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
    public class AdmissionInterviewController : Controller
    {
		private int PageSize = 25;
		private ICenterRepository dbRepository;
		public AdmissionInterviewController(ICenterRepository repo)
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

			IQueryable<AdmissionInterview> interviews =
				dbRepository.GetAllAdmissionInterviews().Skip((page - 1) * PageSize).Take(PageSize);
			AdmissionInterviewsListViewModel model = new AdmissionInterviewsListViewModel { Interviews = interviews, PagingInfo = pagingInfo };

			return View(model);
		}

		public ViewResult Edit(int id, int studentId)
		{
			AdmissionInterviewEditModel viewModel = null;

			AdmissionInterview interview = dbRepository.GetAllAdmissionInterviews().FirstOrDefault<AdmissionInterview>(x => x.ID == id);
			if (interview != null)
			{
				viewModel = new AdmissionInterviewEditModel();

				viewModel.Date = interview.Date;
				viewModel.MemorizationAmount = interview.MemorizationAmount;
				viewModel.Result = interview.Result;
				viewModel.Notes = interview.Notes;
			}

			viewModel.StudentID = studentId;

			return View(viewModel);
		}

		public ViewResult Create(int studentId)
		{
			return View("Edit", new AdmissionInterviewEditModel { StudentID = studentId, Date = DateTime.Now });
		}

		[HttpPost]
		public ActionResult Edit(AdmissionInterviewEditModel interview)
		{
			if (ModelState.IsValid)
			{
				bool newsClass = (interview.ID == 0);

				AdmissionInterview interviewEntity = new AdmissionInterview();
				interviewEntity.ID = interview.ID;
				interviewEntity.Date = interview.Date;
				interviewEntity.MemorizationAmount = interview.MemorizationAmount;
				interviewEntity.Result = interview.Result;
				interviewEntity.Notes = interview.Notes;

				dbRepository.SaveAddmissionInterview(interviewEntity, interview.StudentID);
				TempData["message"] = newsClass ? Messages.AdmissionInterviewCreated : Messages.AdmissionInterviewUpdated;

				return RedirectToAction("Edit", "Student", new { id = interview.StudentID });
			}
			else
			{
				return View(interview);
			}
		}
    }
}
