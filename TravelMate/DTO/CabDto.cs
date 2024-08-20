using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TravelMate.Models;

namespace TravelMate.DTO
{
	public class CabDto 
	{ 	
		public int CabId { get; set; } 
		public int DriverId { get; set; }
		public string VehicleName { get; set; } = string.Empty;

		public string RegistrationNumber { get; set; } = string.Empty;

		public string LicenseNumber { get; set; } = string.Empty;

		public string CabPhoto { get; set; } = string.Empty;

		public string DriverPhoto { get; set; } = string.Empty;

		public decimal Latitude { get; set; }

		public decimal Longitude { get; set; }

		public bool AvailabilityStatus { get; set; }

		public VehicleType VehicleType { get; set; }

		public int NumberOfSeats { get; set; }

		public decimal PricePerKm { get; set; }

		public decimal Rating { get; set; }
	}
}
