using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TravelMate.DTO;
using TravelMate.Services;

namespace TravelMate.Controllers
{
	[Route("api/hotels")]
	[ApiController]
	[EnableCors("cors")]
	public class HotelController : ControllerBase
	{
		private readonly IHotelService _service;

		public HotelController(IHotelService service)
		{
			_service = service;
		}

		[HttpGet("AllHotels")]
		public async Task<ActionResult<List<HotelDto>>> GetAll(int currentUserId)
		{
			try
			{
				var hotels = await _service.GetAll(currentUserId);
				return Ok(hotels);
			}
			catch (Exception ex)
			{
				return NotFound(ex.Message);
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<HotelDto>> Get(int id, int currentUserId)
		{
			try
			{
				var hotel = await _service.Get(id,currentUserId);
				return Ok(hotel);
			}
			catch (Exception ex)
			{
				return NotFound(ex.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] HotelDto hotel, int currentUserId)
		{
			try
			{
				await _service.Add(hotel,currentUserId);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put([FromBody] HotelDto hotel, int currentUserId)
		{
			try
			{
				await _service.Update(hotel,currentUserId);
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
