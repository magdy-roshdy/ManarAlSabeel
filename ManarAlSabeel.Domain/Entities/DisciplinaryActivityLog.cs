using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class DisciplinaryActivityLog
	{
		public virtual int ID { get; set; }
		public virtual RegisteredStudent RegisteredStudent { get; set; }
		public virtual DateTime Date { get; set; }
		public virtual string Reason { get; set; }
		public virtual string Details { get; set; }
		public virtual string Comments { get; set; }
	}
}
