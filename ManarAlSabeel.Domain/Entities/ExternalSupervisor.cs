using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class ExternalSupervisor
	{
		public virtual int ID { get; set; }
		public virtual string Name { get; set; }
		public virtual Sex Sex { get; set; }
	}
}
