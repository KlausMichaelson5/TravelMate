using System.Net.Http.Json;
using TravelMate.Models;

namespace TravelMate2.Services
{
    public interface IHotelService
    {
        Task Add(Hotel hotel);
        Task<Hotel> Get(int id);
        Task Update(Hotel hotel);
        Task Delete(int id);
        Task<List<Hotel>> GetAll();
    }

    public class HotelService : IHotelService
    {
        private readonly HttpClient _httpClient;

        public HotelService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Add(Hotel hotel)
        {
            await _httpClient.PostAsJsonAsync("hotels", hotel);
        }

        public async Task<Hotel> Get(int id)
        {
            var response = await _httpClient.GetAsync($"hotels/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Hotel>();
            }
            else
            {
                throw new Exception("Hotel not found");
            }
        }

        public async Task Update(Hotel hotel)
        {
            await _httpClient.PutAsJsonAsync($"hotels/{hotel.HotelOwnerId}", hotel);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"hotels/{id}");
        }

        public async Task<List<Hotel>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Hotel>>("hotels/AllHotels");
        }
    }
}
