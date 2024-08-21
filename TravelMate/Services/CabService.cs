using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TravelMate.DTO;
using TravelMate.Models;

namespace TravelMate.Services
{
	public interface ICabService
	{
		Task Add(CabDto cab);
		Task Delete(int id);
		Task<CabDto> Get();
		Task Update(CabDto cab);
	}

	public class CabService : ICabService
	{
		private readonly TravelMateDbContext _context;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public CabService(TravelMateDbContext context, IHttpContextAccessor httpContextAccessor)
		{
			_context = context;
			_httpContextAccessor = httpContextAccessor;
		}

		private int GetCurrentUserId()
		{
			var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
			return int.Parse(userId);
		}

		public async Task<CabDto> Get()
		{
			var currentUserId = GetCurrentUserId();
			var cabEntity = await _context.Cabs.FirstOrDefaultAsync(c => c.DriverId == currentUserId);

			if (cabEntity == null)
			{
				throw new Exception("No cab found for the current user.");
			}

			return new CabDto
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
			var currentUserId = GetCurrentUserId();

			var cabEntity = new Cab
			{
				DriverId = currentUserId,
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
			var currentUserId = GetCurrentUserId();
			var cabEntity = await _context.Cabs.FindAsync(cab.CabId);

			if (cabEntity == null || cabEntity.DriverId != currentUserId)
			{
				throw new Exception("Cab not found or you do not have access to update.");
			}

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
			var currentUserId = GetCurrentUserId();
			var cabEntity = await _context.Cabs.FindAsync(id);

			if (cabEntity == null || cabEntity.DriverId != currentUserId)
			{
				throw new Exception("Cab not found or you do not have access to delete.");
			}

			_context.Cabs.Remove(cabEntity);
			await _context.SaveChangesAsync();
		}
	}
}