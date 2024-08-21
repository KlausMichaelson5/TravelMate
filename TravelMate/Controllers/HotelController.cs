﻿using Microsoft.AspNetCore.Cors;
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
		public async Task<ActionResult<List<HotelDto>>> GetAll()
		{
			try
			{
				var hotels = await _service.GetAll();
				return Ok(hotels);
			}
			catch (Exception ex)
			{
				return NotFound(ex.Message);
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<HotelDto>> Get(int id)
		{
			try
			{
				var hotel = await _service.Get(id);
				return Ok(hotel);
			}
			catch (Exception ex)
			{
				return NotFound(ex.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] HotelDto hotel)
		{
			try
			{
				await _service.Add(hotel);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] HotelDto hotel)
		{
			try
			{
				await _service.Update(hotel);
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
