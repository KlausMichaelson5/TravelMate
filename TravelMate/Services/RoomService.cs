using global::TravelMate.DTO;
using global::TravelMate.Models;
using Microsoft.EntityFrameworkCore;
using TravelMate.DTO;
using TravelMate.Models;
namespace TravelMate.Services
{
	public interface IRoomService
	{
		Task Add(RoomDto room);
		Task Delete(int id);
		Task<RoomDto> Get(int id);
		Task<List<RoomDto>> GetAll();
		Task Update(int id,RoomDto room);
	}
	public class RoomService : IRoomService
	{
		private readonly TravelMateDbContext _context;

		public RoomService(TravelMateDbContext context)
		{
			_context = context;
		}

		public async Task<List<RoomDto>> GetAll()
		{
			var rooms = await _context.Rooms
				.Select(room => new RoomDto
				{
					RoomId = room.RoomId,
					HotelId = room.HotelId,
					RoomType = room.RoomType,
					Price = room.Price,
					AvailabilityStatus = room.AvailabilityStatus,
					RoomImage = room.RoomImage
				})
				.ToListAsync();

			return rooms;
		}

		public async Task<RoomDto> Get(int id)
		{
			var room = await _context.Rooms
				.Where(r => r.RoomId == id)
				.Select(room => new RoomDto
				{
					RoomId = room.RoomId,
					HotelId = room.HotelId,
					RoomType = room.RoomType,
					Price = room.Price,
					AvailabilityStatus = room.AvailabilityStatus,
					RoomImage = room.RoomImage
				})
				.FirstOrDefaultAsync();

			if (room == null)
			{
				throw new Exception($"Room with id {id} not found.");
			}

			return room;
		}

		public async Task Add(RoomDto roomDto)
		{
			var room = new Room
			{
				HotelId = roomDto.HotelId,
				RoomType = roomDto.RoomType,
				Price = roomDto.Price,
				AvailabilityStatus = roomDto.AvailabilityStatus,
				RoomImage = roomDto.RoomImage
			};

			await _context.Rooms.AddAsync(room);
			await _context.SaveChangesAsync();
		}

		public async Task Update(int id, RoomDto roomDto)
		{
			var existingRoom = await _context.Rooms.FindAsync(id);

			if (existingRoom == null)
			{
				throw new Exception("Room not found to update.");
			}

			existingRoom.HotelId = roomDto.HotelId;
			existingRoom.RoomType = roomDto.RoomType;
			existingRoom.Price = roomDto.Price;
			existingRoom.AvailabilityStatus = roomDto.AvailabilityStatus;
			existingRoom.RoomImage = roomDto.RoomImage;

			await _context.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var room = await _context.Rooms.FindAsync(id);

			if (room == null)
			{
				throw new Exception("Room not found to delete.");
			}

			_context.Rooms.Remove(room);
			await _context.SaveChangesAsync();
		}
	}
}

