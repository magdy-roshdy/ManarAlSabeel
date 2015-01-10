using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManarAlSabeel.Web.Models
{
    public class DisciplinaryActivityEitViewModel
    {
        public int ID { get; set; }
        public int RegistredStudentID { get; set; }


        [Required(ErrorMessageResourceType = typeof(ManarAlSabeel.Resources.Messages),
              ErrorMessageResourceName = "DisciplinaryActivityDateIsRequired")]
        public DateTime Date { get; set; }

        
        [Required(ErrorMessageResourceType = typeof(ManarAlSabeel.Resources.Messages),
              ErrorMessageResourceName = "DisciplinaryActivityReasonIsRequired")]
        public string Reason { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessageResourceType = typeof(ManarAlSabeel.Resources.Messages),
              ErrorMessageResourceName = "DisciplinaryActivityDetailsIsRequired")]
        public string Details { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }
    }
}