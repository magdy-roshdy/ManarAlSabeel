using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class RegisteredStudent
	{
		public virtual int ID { get; set; }

		public virtual Student Student { get; set; }
		public virtual Class Class { get; set; }
		public virtual Stage Stage { get; set; }

		//Branch and Sex properties are added only because of NH filters!
		public virtual Branch Branch { get; set; }
		public virtual Sex Sex { get; set; }

		public virtual DateTime Date { get; set; }
		public virtual string Comments { get; set; }

		public virtual IList<Exam> Exams { get; set; }

        public virtual IList<DisciplinaryActivityLog> DisciplinaryActivities { get; set; }
	}
}
