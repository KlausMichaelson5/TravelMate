using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TravelMate.Models;

namespace TravelMate2.Services
{
    public interface ICabService
    {
        Task<List<Cab>> GetAllCabs();
        Task<Cab> GetCab(int cabId);
        Task AddCab(Cab cab);
        Task UpdateCab(Cab cab);
        Task DeleteCab(int cabId);
    }

    public class CabService : ICabService
    {
        private readonly HttpClient httpClient;

        public CabService(HttpClient client)
        {
            this.httpClient = client;
        }

        public async Task<List<Cab>> GetAllCabs()
        {
            return await httpClient.GetFromJsonAsync<List<Cab>>("cabs");
        }

        public async Task<Cab> GetCab(int cabId)
        {
            return await httpClient.GetFromJsonAsync<Cab>($"cabs/{cabId}");
        }

        public async Task AddCab(Cab cab)
        {
            await httpClient.PostAsJsonAsync("addcab", cab);
        }

        public async Task UpdateCab(Cab cab)
        {
            await httpClient.PutAsJsonAsync($"cabs/{cab.CabId}", cab);
        }

        public async Task DeleteCab(int cabId)
        {
            await httpClient.DeleteAsync($"cabs/{cabId}");
        }
    }
}