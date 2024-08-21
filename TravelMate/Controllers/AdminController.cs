using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TravelMate.DTO;
using TravelMate.Services;

namespace TravelMate.Controllers
{
	[Route("api/[controller]/[action]")]
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

		[HttpGet]
		[ActionName("GetAllUsers")]
		public async Task<ActionResult<List<UserDto>>> GetAll()
		{
			try
			{
				var users = await AdminService.GetAll();
				return users;
			}
			catch (Exception ex)
			{
				return NotFound(ex.Message);
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await AdminService.Delete(id);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		[ActionName("GetAdmin")]
		public async Task<ActionResult<UserDto>> Login(string username, string password)
		{
			try
			{
				var user = await UserService.Login(username, password);
				return user;
			}
			catch (Exception ex)
			{
				return NotFound(ex.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] UserDto user)
		{
			try
			{
				await UserService.Register(user);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] UserDto user)
		{
			try
			{
				await UserService.Update(user);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

	}
}
