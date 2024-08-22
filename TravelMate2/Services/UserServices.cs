using System.Net.Http.Json;
using TravelMate.Models;

namespace TravelMate2.Services
{
    public interface IUserService
    {
        //Task<List<User>> PostUser();
        Task Add(User user);
        Task<User> Login(string username,string password);
    }
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;

        public UserService(HttpClient client)
        {
            this.httpClient = client;
        }
        public async Task Add(User user)
        {
             await httpClient.PostAsJsonAsync<User>("users/", user);
            
        }

        public async Task<User> Login(string username,string password)
        {
            var response = await httpClient.GetAsync($"users/?username={username}&password={password}");
            if(response.IsSuccessStatusCode)
            {
                var authenticatedUser=await response.Content.ReadFromJsonAsync<User>();
                return authenticatedUser;
            }
            else
            {
                throw new Exception("Invalid Credentials");
            }
        }
    }
}


