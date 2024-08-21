using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TravelMate2.Services;

namespace TravelMate2
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var baseAddress = "http://localhost:5258/api/users/";
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
            builder.Services.AddTransient<IUserService, UserService>();
            await builder.Build().RunAsync();
        }
    }
}
