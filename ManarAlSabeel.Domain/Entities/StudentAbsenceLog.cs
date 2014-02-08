using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class StudentAbsenceLog
	{
		public virtual RegisteredStudent RegisteredStudent { get; set; }
		public virtual DateTime Date { get; set; }
		public virtual bool IsHasAnExcuse { get; set; }
		public virtual string ExcuseDetails { get; set; }

		//public virtual SystemUser LoggedBy { get; set; }
	}
}
