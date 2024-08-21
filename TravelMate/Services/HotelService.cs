using Microsoft.EntityFrameworkCore;
using TravelMate.DTO;
using TravelMate.Models;

namespace TravelMate.Services
{
	public interface IHotelService
	{
		Task Add(HotelDto hotel);
		Task Delete(int id);
		Task<HotelDto> Get(int id);
		Task<List<HotelDto>> GetAll();
		Task Update(HotelDto hotel);
	}

	public class HotelService : IHotelService
	{
		private readonly TravelMateDbContext _context;

		public HotelService(TravelMateDbContext context)
		{
			_context = context;
		}

		public async Task<List<HotelDto>> GetAll()
		{
			var hotels = new List<HotelDto>();
			var hotelEntities = await _context.Hotels.ToListAsync();

			foreach (var hotelEntity in hotelEntities)
			{
				var hotel = new HotelDto
				{
					HotelId = hotelEntity.HotelId,
					HotelOwnerId = hotelEntity.HotelOwnerId,
					Name = hotelEntity.Name,
					Address = hotelEntity.Address,
					City = hotelEntity.City,
					State = hotelEntity.State,
					Country = hotelEntity.Country,
					ZipCode = hotelEntity.ZipCode,
					Description = hotelEntity.Description,
					Latitude = hotelEntity.Latitude,
					Longitude = hotelEntity.Longitude,
					Rating = hotelEntity.Rating,
					AvailabilityStatus = hotelEntity.AvailabilityStatus,
					HotelImage = hotelEntity.HotelImage
				};

				hotels.Add(hotel);
			}

			return hotels;
		}

		public async Task<HotelDto> Get(int id)
		{
			var hotelEntity = await _context.Hotels.FindAsync(id);
			if (hotelEntity == null)
			{
				throw new Exception($"Hotel with id {id} not found.");
			}
			return new HotelDto
			{
				HotelId = hotelEntity.HotelId,
				HotelOwnerId = hotelEntity.HotelOwnerId,
				Name = hotelEntity.Name,
				Address = hotelEntity.Address,
				City = hotelEntity.City,
				State = hotelEntity.State,
				Country = hotelEntity.Country,
				ZipCode = hotelEntity.ZipCode,
				Description = hotelEntity.Description,
				Latitude = hotelEntity.Latitude,
				Longitude = hotelEntity.Longitude,
				Rating = hotelEntity.Rating,
				AvailabilityStatus = hotelEntity.AvailabilityStatus,
				HotelImage = hotelEntity.HotelImage
			};
		}

		public async Task Update(HotelDto hotel)
		{
			var existingHotel = await _context.Hotels.FindAsync(hotel.HotelId);
			if (existingHotel != null)
			{
				existingHotel.Name = hotel.Name;
				existingHotel.Address = hotel.Address;
				existingHotel.City = hotel.City;
				existingHotel.State = hotel.State;
				existingHotel.Country = hotel.Country;
				existingHotel.ZipCode = hotel.ZipCode;
				existingHotel.Description = hotel.Description;
				existingHotel.Latitude = hotel.Latitude;
				existingHotel.Longitude = hotel.Longitude;
				existingHotel.Rating = hotel.Rating;
				existingHotel.AvailabilityStatus = hotel.AvailabilityStatus;
				existingHotel.HotelImage = hotel.HotelImage;

				await _context.SaveChangesAsync();
			}
			else
			{
				throw new Exception("Hotel not found to update.");
			}
		}

		public async Task Add(HotelDto hotel)
		{
			await _context.Hotels.AddAsync(new Hotel
			{
				HotelOwnerId = hotel.HotelOwnerId,
				Name = hotel.Name,
				Address = hotel.Address,
				City = hotel.City,
				State = hotel.State,
				Country = hotel.Country,
				ZipCode = hotel.ZipCode,
				Description = hotel.Description,
				Latitude = hotel.Latitude,
				Longitude = hotel.Longitude,
				Rating = hotel.Rating,
				AvailabilityStatus = hotel.AvailabilityStatus,
				HotelImage = hotel.HotelImage
			});

			await _context.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var hotel = await _context.Hotels.FindAsync(id);
			if (hotel != null)
			{
				_context.Hotels.Remove(hotel);
				await _context.SaveChangesAsync();
			}
			else
			{
				throw new Exception("Hotel not found to delete.");
			}
		}
	}
}
