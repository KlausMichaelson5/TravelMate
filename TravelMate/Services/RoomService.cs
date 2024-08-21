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

		public async Task<List<RoomDto>> GetAll(int hotelId)
		{
			var rooms = await _context.Rooms
				.Where(room=>room.HotelId== hotelId)
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

		public async Task<RoomDto> Get(int id, int hotelId)
		{
			var room = await _context.Rooms
				.Where(r => r.RoomId == id && r.HotelId==hotelId)
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

		public async Task Add(RoomDto roomDto, int hotelId)
		{
			var room = new Room
			{
				HotelId = hotelId,   //should add a check for matching hotelids
				RoomType = roomDto.RoomType,
				Price = roomDto.Price,
				AvailabilityStatus = roomDto.AvailabilityStatus,
				RoomImage = roomDto.RoomImage
			};

			await _context.Rooms.AddAsync(room);
			await _context.SaveChangesAsync();
		}

		public async Task Update(RoomDto roomDto, int hotelId)
		{
			var existingRoom = await _context.Rooms.FindAsync(roomDto.RoomId);

			if (existingRoom == null || existingRoom.HotelId!=hotelId)
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

		public async Task Delete(int id, int hotelId)
		{
			var room = await _context.Rooms.FindAsync(id);

			if (room == null || room.HotelId!=hotelId)
			{
				throw new Exception("Room not found to delete.");
			}

			_context.Rooms.Remove(room);
			await _context.SaveChangesAsync();
		}
	}
}

