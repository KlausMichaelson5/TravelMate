//using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using TravelMate.DTO;
//using TravelMate.Services;

//namespace TravelMate.Controllers
//{
//	[Route("api/rooms")]
//	[ApiController]
//	[EnableCors("cors")]
//	public class RoomController : ControllerBase
//	{
//		private readonly IRoomService _service;

//		public RoomController(IRoomService roomService)
//		{
//			_service = roomService;
//		}

//		[HttpGet("AllRooms")]
//		public async Task<ActionResult<List<RoomDto>>> GetAll()
//		{
//			try
//			{
//				var rooms = await _service.GetAll();
//				return Ok(rooms);
//			}
//			catch (Exception ex)
//			{
//				return NotFound(ex.Message);
//			}
//		}

//		[HttpGet("{id}")]
//		public async Task<ActionResult<RoomDto>> Get(int id)
//		{
//			try
//			{
//				var room = await _service.Get(id);
//				return Ok(room);
//			}
//			catch (Exception ex)
//			{
//				return NotFound(ex.Message);
//			}
//		}

//		[HttpPost]
//		public async Task<IActionResult> Post([FromBody] RoomDto room)
//		{
//			try
//			{
//				await _service.Add(room);
//				return Ok();
//			}
//			catch (Exception ex)
//			{
//				return BadRequest(ex.Message);
//			}
//		}

//		[HttpPut("{id}")]
//		public async Task<IActionResult> Put(int id, [FromBody] RoomDto room)
//		{
//			try
//			{
//				await _service.Update(id, room);
//				return Ok();
//			}
//			catch (Exception ex)
//			{
//				return BadRequest(ex.Message);
//			}
//		}

//		[HttpDelete("{id}")]
//		public async Task<IActionResult> Delete(int id)
//		{
//			try
//			{
//				////await _service.Delete(id);
//				return Ok();
//			}
//			catch (Exception ex)
//			{
//				return BadRequest(ex.Message);
//			}
//		}
//	}
//}
