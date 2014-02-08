using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class TeacherAbsenceLog
	{
		public virtual int ID { get; set; }
		public virtual DateTime Date { get; set; }
		public virtual bool IsHasExcuse { get; set; }
		public virtual string ExcuseDetails { get; set; }
		
		public virtual Teacher Teacher { get; set; }
		//public virtual SystemUser LoggedBy { get; set; }
	}
}
