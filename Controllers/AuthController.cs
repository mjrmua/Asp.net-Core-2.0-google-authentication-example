using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace GoogleAuthExample.Controllers
{
	public class AuthController : Controller
    {
		[Authorize]
		[Route("secret")]
		public IActionResult Secret()
		{
			return View(new User(this.User));
		}

		[Route("home")]
		public IActionResult Home()
		{
			return View(this.User.Identities.Any(v=>v.IsAuthenticated));
		}
	}
}
