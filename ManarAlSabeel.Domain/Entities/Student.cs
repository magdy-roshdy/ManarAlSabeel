using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using ManarAlSabeel.Resources;

namespace ManarAlSabeel.Domain.Entities
{
	public class Student
	{
		[Key]
		public virtual int ID { get; set; }
		
		[Required]
		public virtual StudentGuardian Guardian { get; set; }

		[Required]
		public virtual Branch Branch { get; set; }

		[Required(ErrorMessageResourceType = typeof(ManarAlSabeel.Resources.Messages),
			  ErrorMessageResourceName = "StudentNameRequired")]
		public virtual string Name { get; set; }

		[Required(ErrorMessageResourceType = typeof(ManarAlSabeel.Resources.Messages),
			  ErrorMessageResourceName = "StudentBirthdayRequired")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public virtual DateTime BirthDate { get; set; }

		public virtual string PersonalPhotoPath { get; set; }

		[Required]
		public virtual Country OriginalNationality { get; set; }
		public virtual Country AcquiredNationality { get; set; }
		public virtual string SchoolName { get; set; }
		public virtual string LastEducationDegree { get; set; }
		public virtual string EducationStage { get; set; }
		public virtual string SchoolClass { get; set; }
		public virtual HowKnewTheCenter HowKnewTheCenter { get; set; }
		public virtual int ExpectedQuraanFinishTime { get; set; }
		public virtual bool IsInTransportations { get; set; }
		public virtual Sex Sex { get; set; }
		public virtual StudentStatus Status { get; set; }
		public virtual DateTime AddedOn { get; set; }

		public virtual int Age
		{
			get
			{
				return DateTime.Now.Year - this.BirthDate.Year;
			}
		}
	}
}
