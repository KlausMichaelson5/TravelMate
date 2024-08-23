using HotelBookingDll.Models;
using HotelBookingDll.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingWebApi.Services
{
    public interface IHotelBookingDataService
    {
        Task AddBookingAsync(HotelBookingTable booking, int currentUserId);
        Task DeleteBookingByIdAsync(int id, int currentUserId);
        Task<HotelBookingTable> GetBookingByIdAsync(int id, int currentUserId);
        Task<List<HotelBookingTable>> GetAllBookingsAsync(int currentUserId);
    }

    public class HotelBookingDataService : IHotelBookingDataService
    {
        private readonly IHotelBookingService _hotelBookingService;

        public HotelBookingDataService(IHotelBookingService hotelBookingService)
        {
            _hotelBookingService = hotelBookingService;
        }

        public Task AddBookingAsync(HotelBookingTable booking, int currentUserId)
        {
            return Task.Run(() => _hotelBookingService.AddNewBooking(booking, currentUserId));
        }

        public Task DeleteBookingByIdAsync(int id, int currentUserId)
        {
            return Task.Run(() => _hotelBookingService.DeleteBooking(id, currentUserId));
        }

        public Task<HotelBookingTable> GetBookingByIdAsync(int id, int currentUserId)
        {
            return Task.Run(() => _hotelBookingService.GetBookingById(id, currentUserId));
        }

        public Task<List<HotelBookingTable>> GetAllBookingsAsync(int currentUserId)
        {
            return Task.Run(() => _hotelBookingService.GetAllBookings(currentUserId));
        }
    }
}
