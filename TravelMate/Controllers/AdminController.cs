using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TravelMate.Services;

namespace TravelMate.Controllers
{
	[Route("api/admin")]
	[ApiController]
	[EnableCors("cors")]
	public class AdminController : ControllerBase
	{
		private readonly IUserService UserService;
		private readonly IAdminService AdminService;
		public AdminController(IUserService userService,IAdminService adminService)
		{
			UserService = userService;
			AdminService = adminService;
		}

	}
}
