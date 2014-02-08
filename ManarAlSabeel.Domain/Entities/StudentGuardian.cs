using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class StudentGuardian
	{
		public virtual int ID { get; set; }
		public virtual string Name { get; set; }
		public virtual string HomePhone { get; set; }
		public virtual string MobilePhone { get; set; }
		public virtual string OtherPhone { get; set; }
		public virtual string HomeAddress { get; set; }
		public virtual string Email { get; set; }
		public virtual Sex Sex { get; set; }
	}
}
