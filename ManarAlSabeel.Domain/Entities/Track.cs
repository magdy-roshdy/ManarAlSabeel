﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Domain.Entities
{
	public class Track
	{
		public virtual int ID { get; set; }
		public virtual string Name { get; set; }
		public virtual Branch Branch { get; set; }
	}
}
