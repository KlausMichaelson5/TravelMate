using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TravelMate.DTO;
using TravelMate.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TravelMate.Controllers
{
	[Route("api/cabs")]
	[ApiController]
	[EnableCors("cors")]
	public class CabController : ControllerBase
	{
		private readonly ICabService _service;

		public CabController(ICabService service)
		{
			_service = service;
		}


		[HttpGet("{id}")]
		public async Task<ActionResult<CabDto>> Get(int currentUserId)
		{
			try
			{
				var cab = await _service.Get(currentUserId);
				return Ok(cab);
			}
			catch (Exception ex)
			{
				return NotFound(ex.Message);
			}
		}

		[HttpPost("addcab")]
		public async Task<IActionResult> Post([FromBody] CabDto cab, int currentUserId)
		{
			try
			{
				await _service.Add(cab,currentUserId);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put([FromBody] CabDto cab, int currentUserId)
		{
			try
			{
				await _service.Update(cab,currentUserId);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id, int currentUserId)
		{
			try
			{
				await _service.Delete(id,currentUserId);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}