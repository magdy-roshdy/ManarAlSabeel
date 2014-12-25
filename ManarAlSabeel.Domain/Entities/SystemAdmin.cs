using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class SystemAdmin
	{
		public virtual int ID { get; set; }
		public virtual string Email { get; set; }
		public virtual string Password { get; set; }
		public virtual bool IsActive { get; set; }
		public virtual bool IsSuperAdmin { get; set; }
		public virtual int LoginPersonType { get; set; }
		public virtual Branch Branch { get; set; }
		public virtual Sex? SexToManage { get; set; }
		public virtual DateTime LastLogin { get; set; }
	}
}
