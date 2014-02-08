using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManarAlSabeel.Web.Infrastructure
{
	public interface IAuthProvider
	{
		bool Authenticate(string username, string password);
	}
}
