using System.Security.Claims;

namespace GoogleAuthExample.Controllers
{
	public class User
	{
		private ClaimsPrincipal principal;

		public User(ClaimsPrincipal principal) {
			this.principal = principal;
		}
		public string Name => principal.Identity.Name;
		public string Email => principal.FindFirst(ClaimTypes.Email).Value;
	}
}
