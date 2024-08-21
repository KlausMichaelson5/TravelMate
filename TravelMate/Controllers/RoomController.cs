using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelMate.DTO;
using TravelMate.Services;

namespace TravelMate.Controllers
{
	[Route("api/rooms")]
	[ApiController]
	[EnableCors("cors")]
	public class RoomController : ControllerBase
	{
		private readonly IRoomService _service;

		public RoomController(IRoomService roomService)
		{
			_service = roomService;
		}

		[HttpGet("AllRooms")]
		public async Task<ActionResult<List<RoomDto>>> GetAll(int hotelId)
		{
			try
			{
				var rooms = await _service.GetAll(hotelId);
				return Ok(rooms);
			}
			catch (Exception ex)
			{
				return NotFound(ex.Message);
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<RoomDto>> Get(int id,int hotelId)
		{
			try
			{
				var room = await _service.Get(id,hotelId);
				return Ok(room);
			}
			catch (Exception ex)
			{
				return NotFound(ex.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] RoomDto room,int hotelId)
		{
			try
			{
				await _service.Add(room,hotelId);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int hotelId, [FromBody] RoomDto room)
		{
			try
			{
				await _service.Update(room,hotelId);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id,int hotelId)
		{
			try
			{
				await _service.Delete(id,hotelId);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
