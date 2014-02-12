using ManarAlSabeel.Web.Infrastructure;
using ManarAlSabeel.Web.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Profile;
using System.Web.Security;

namespace ManarAlSabeel.Web.Controllers
{
    public class SystemAdminsController : Controller
    {
		private IAuthProvider authProvider;
		public SystemAdminsController(IAuthProvider authProvider)
		{
			this.authProvider = authProvider;
		}

        public ActionResult Login()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Login(string email, string password, string ReturnUrl)
		{
			if(ModelState.IsValid)
			{
				if(authProvider.Authenticate(email, password))
				{
					return Redirect(string.Format("{0}?{1}={2}", Url.Action("SetProfileInfo"), "ReturnUrl", ReturnUrl));
				}
				else
				{
					ModelState.AddModelError("", "incorrect username or password");
					return View();
				}
			}
			else
			{
				return View("Login");
			}
		}

		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();

			return Redirect(Url.Action("Index", "Home"));
		}

		public ActionResult SetProfileInfo(string ReturnUrl)
		{
			HttpContext.Profile["SexFilter"] = 1;
			HttpContext.Profile["BranchFilter"] = 1;

			return string.IsNullOrEmpty(ReturnUrl) ? Redirect(Url.Action("Index", "Home")) : Redirect(ReturnUrl);
		}
    }
}
