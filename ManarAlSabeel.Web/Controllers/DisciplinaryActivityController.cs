using ManarAlSabeel.Domain.Abstract;
using ManarAlSabeel.Domain.Entities;
using ManarAlSabeel.Resources;
using ManarAlSabeel.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManarAlSabeel.Web.Controllers
{
    public class DisciplinaryActivityController : Controller
    {
        private ICenterRepository dbRepository;
        public DisciplinaryActivityController(ICenterRepository repo)
		{
			dbRepository = repo;
		}
       
        public ActionResult Create(int registeredStudentId)
        {
            DisciplinaryActivityEitViewModel disciplinaryActivityEditViewModel = new DisciplinaryActivityEitViewModel();
            disciplinaryActivityEditViewModel.Date = DateTime.Now;
            disciplinaryActivityEditViewModel.RegistredStudentID = registeredStudentId;

            

            return View("Edit", disciplinaryActivityEditViewModel);
        }

        public ViewResult Edit(int id)
        {
            DisciplinaryActivityEitViewModel disciplinaryActivityEditViewModel = null;
            DisciplinaryActivityLog disciplinaryActivityEntity = dbRepository.GetStudentDisciplinaryActivities().FirstOrDefault<DisciplinaryActivityLog>(x => x.ID == id);
            if (disciplinaryActivityEntity != null)
            {
                disciplinaryActivityEditViewModel = new DisciplinaryActivityEitViewModel();
                disciplinaryActivityEditViewModel.ID = disciplinaryActivityEntity.ID;
                disciplinaryActivityEditViewModel.RegistredStudentID = disciplinaryActivityEntity.RegisteredStudent.ID;
                disciplinaryActivityEditViewModel.Reason = disciplinaryActivityEntity.Reason;
                disciplinaryActivityEditViewModel.Details = disciplinaryActivityEntity.Details;
                disciplinaryActivityEditViewModel.Date = disciplinaryActivityEntity.Date;
                disciplinaryActivityEditViewModel.Comments = disciplinaryActivityEntity.Comments;
             
            }

            return View(disciplinaryActivityEditViewModel);
        }

        [HttpPost]
        public ActionResult Edit(DisciplinaryActivityEitViewModel disciplinaryActivityEditViewModel)
        {
            if (ModelState.IsValid)
            {
                bool newsDisciplinaryActivity = (disciplinaryActivityEditViewModel.ID == 0);

                DisciplinaryActivityLog disciplinaryActivityEntity = new DisciplinaryActivityLog();
                disciplinaryActivityEntity.ID = disciplinaryActivityEditViewModel.ID;
                disciplinaryActivityEntity.RegisteredStudent = new RegisteredStudent { ID = disciplinaryActivityEditViewModel.RegistredStudentID };
                disciplinaryActivityEntity.Reason = disciplinaryActivityEditViewModel.Reason;
                disciplinaryActivityEntity.Details = disciplinaryActivityEditViewModel.Details;
                disciplinaryActivityEntity.Comments = string.IsNullOrWhiteSpace(disciplinaryActivityEditViewModel.Comments) ? null : disciplinaryActivityEditViewModel.Comments;
                disciplinaryActivityEntity.Date = disciplinaryActivityEditViewModel.Date;

                dbRepository.SaveDisciplinaryActivity(disciplinaryActivityEntity);
                TempData["message"] = newsDisciplinaryActivity ? Messages.DisciplinaryActivityAdded : Messages.DisciplinaryActivityEditedSuccessfully;

                return RedirectToAction("Edit", "DisciplinaryActivity", new { id = disciplinaryActivityEditViewModel.RegistredStudentID });
            }
            else
            {
                return View(disciplinaryActivityEditViewModel);
            }
        }

        public ViewResult List(int? registeredStudentId)
        {
            IQueryable<DisciplinaryActivityLog> DisciplinaryActivities = null;
            if (registeredStudentId.HasValue)
                DisciplinaryActivities = dbRepository.GetStudentDisciplinaryActivities().Where(disciplinaryActivity => disciplinaryActivity.RegisteredStudent.ID == registeredStudentId.Value).OrderBy(disciplinaryActivity => disciplinaryActivity.Date);
            else
                DisciplinaryActivities = dbRepository.GetStudentDisciplinaryActivities().Where(disciplinaryActivity => disciplinaryActivity.ID == 0);

            return View(new DisciplinaryActivitiesListModel { DisciplinaryActivities = DisciplinaryActivities });
        }

        
    }
}
