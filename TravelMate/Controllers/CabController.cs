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

		[HttpGet("AllCabs")]
		public async Task<ActionResult<List<CabDto>>> GetAll()
		{
			try
			{
				var cabs = await _service.GetAll();
				return Ok(cabs);
			}
			catch (Exception ex)
			{
				return NotFound(ex.Message);
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<CabDto>> Get(int id)
		{
			try
			{
				var cab = await _service.Get(id);
				return Ok(cab);
			}
			catch (Exception ex)
			{
				return NotFound(ex.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CabDto cab)
		{
			try
			{
				await _service.Add(cab);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] CabDto cab)
		{
			try
			{
				await _service.Update(cab);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await _service.Delete(id);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}