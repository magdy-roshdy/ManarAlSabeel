using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class StudentGuardian
	{
		[Key]
		public virtual int ID { get; set; }

		//[Required]
		public virtual Branch Branch { get; set; }

		//[Required(ErrorMessageResourceType = typeof(ManarAlSabeel.Resources.Messages),
		//	  ErrorMessageResourceName = "GuardianNameIsRequired")]
		public virtual string Name { get; set; }

		public virtual string HomePhone { get; set; }

		//[Required(ErrorMessageResourceType = typeof(ManarAlSabeel.Resources.Messages),
		//	  ErrorMessageResourceName = "GuardianMobileNumberIsRequired")]
		public virtual string MobilePhone { get; set; }

		public virtual string OtherPhone { get; set; }
		public virtual string HomeAddress { get; set; }
		public virtual string Email { get; set; }

		[Required]
		public virtual Sex Sex { get; set; }

		public virtual IList<Student> Children { get; set; }
	}
}
