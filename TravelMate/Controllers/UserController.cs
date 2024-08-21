using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelMate.DTO;
using TravelMate.Models;
using TravelMate.Services;

namespace TravelMate.Controllers
{
	[Route("api/users")]
	[ApiController]
	[EnableCors("cors")]
	public class UserController : ControllerBase
	{
		private readonly IUserService _service;

		public UserController(IUserService userService)
		{
			_service = userService;
		}

		

		[HttpGet("{id}")]
		public async Task<ActionResult<UserDto>> Get(int id)
		{
			try
			{
				var user = await _service.Get(id);
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
				await _service.Add(user);
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
				await _service.Update(user);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		

	}
}
