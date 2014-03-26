using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class Teacher
	{
		public virtual int ID { get; set; }
		public virtual Branch Branch { get; set; }
		public virtual string Name { get; set; }
		public virtual Sex Sex { get; set; }
		public virtual Country Nationality { get; set; }
		public virtual DateTime BirthDate { get; set; }
		public virtual Country BirthPlace { get; set; }
		public virtual MaritalStatus MaritalStatus { get; set; }
		public virtual DateTime? MarriageDate { get; set; }
		public virtual string Profession { get; set; }
		public virtual ReligiousIdeology? ReligiousIdeology { get; set; }
		public virtual string MobileNumber { get; set; }
		public virtual string HomeNumber { get; set; }
		public virtual string Email { get; set; }
		public virtual string AmountOfMemorization { get; set; }
		public virtual bool IsSupervisor { get; set; }
		public virtual TeacherStatus Status { get; set; }

		public virtual int Age
		{
			get
			{
				return DateTime.Now.Year - this.BirthDate.Year;
			}
		}
	}
}
