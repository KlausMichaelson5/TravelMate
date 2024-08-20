using Microsoft.EntityFrameworkCore;
using TravelMate.DTO;
using TravelMate.Models;

namespace TravelMate.Services
{
	public interface ICabService
	{
		Task Add(CabDto cab);
		Task Delete(int id);
		Task<CabDto> Get(int id);
		Task<List<CabDto>> GetAll();
		Task Update(CabDto cab);
	}
	public class CabService : ICabService
	{
		private readonly TravelMateDbContext _context;

		public CabService(TravelMateDbContext context)
		{
			_context = context;
		}

		public async Task<List<CabDto>> GetAll()
		{
			var cabs = new List<CabDto>();
			var cabEntities = await _context.Cabs.ToListAsync();

			foreach (var cabEntity in cabEntities)
			{
				var cab = new CabDto()
				{
					CabId = cabEntity.CabId,
					DriverId = cabEntity.DriverId,
					VehicleName = cabEntity.VehicleName,
					RegistrationNumber = cabEntity.RegistrationNumber,
					LicenseNumber = cabEntity.LicenseNumber,
					CabPhoto = cabEntity.CabPhoto,
					DriverPhoto = cabEntity.DriverPhoto,
					Latitude = cabEntity.Latitude,
					Longitude = cabEntity.Longitude,
					AvailabilityStatus = cabEntity.AvailabilityStatus,
					VehicleType = cabEntity.VehicleType,
					NumberOfSeats = cabEntity.NumberOfSeats,
					PricePerKm = cabEntity.PricePerKm,
					Rating = cabEntity.Rating
				};

				cabs.Add(cab);
			}

			return cabs;
		}

		public async Task<CabDto> Get(int id)
		{
			var cabEntity = await _context.Cabs.FindAsync(id);
			if (cabEntity == null)
			{
				throw new Exception($"Cab with id {id} not found.");
			}

			return new CabDto()
			{
				CabId = cabEntity.CabId,
				DriverId = cabEntity.DriverId,
				VehicleName = cabEntity.VehicleName,
				RegistrationNumber = cabEntity.RegistrationNumber,
				LicenseNumber = cabEntity.LicenseNumber,
				CabPhoto = cabEntity.CabPhoto,
				DriverPhoto = cabEntity.DriverPhoto,
				Latitude = cabEntity.Latitude,
				Longitude = cabEntity.Longitude,
				AvailabilityStatus = cabEntity.AvailabilityStatus,
				VehicleType = cabEntity.VehicleType,
				NumberOfSeats = cabEntity.NumberOfSeats,
				PricePerKm = cabEntity.PricePerKm,
				Rating = cabEntity.Rating
			};
		}

		public async Task Add(CabDto cab)
		{
			var cabEntity = new Cab()
			{
				DriverId = cab.DriverId,
				VehicleName = cab.VehicleName,
				RegistrationNumber = cab.RegistrationNumber,
				LicenseNumber = cab.LicenseNumber,
				CabPhoto = cab.CabPhoto,
				DriverPhoto = cab.DriverPhoto,
				Latitude = cab.Latitude,
				Longitude = cab.Longitude,
				AvailabilityStatus = cab.AvailabilityStatus,
				VehicleType = cab.VehicleType,
				NumberOfSeats = cab.NumberOfSeats,
				PricePerKm = cab.PricePerKm,
				Rating = cab.Rating
			};

			await _context.Cabs.AddAsync(cabEntity);
			await _context.SaveChangesAsync();
		}

		public async Task Update(CabDto cab)
		{
			var cabEntity = await _context.Cabs.FindAsync(cab.CabId);
			if (cabEntity == null)
			{
				throw new Exception("Cab not found to update.");
			}

			cabEntity.DriverId = cab.DriverId;
			cabEntity.VehicleName = cab.VehicleName;
			cabEntity.RegistrationNumber = cab.RegistrationNumber;
			cabEntity.LicenseNumber = cab.LicenseNumber;
			cabEntity.CabPhoto = cab.CabPhoto;
			cabEntity.DriverPhoto = cab.DriverPhoto;
			cabEntity.Latitude = cab.Latitude;
			cabEntity.Longitude = cab.Longitude;
			cabEntity.AvailabilityStatus = cab.AvailabilityStatus;
			cabEntity.VehicleType = cab.VehicleType;
			cabEntity.NumberOfSeats = cab.NumberOfSeats;
			cabEntity.PricePerKm = cab.PricePerKm;
			cabEntity.Rating = cab.Rating;

			await _context.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var cabEntity = await _context.Cabs.FindAsync(id);
			if (cabEntity == null)
			{
				throw new Exception("Cab not found to delete.");
			}

			_context.Cabs.Remove(cabEntity);
			await _context.SaveChangesAsync();
		}
	}
}
