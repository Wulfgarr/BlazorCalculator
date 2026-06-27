using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Globalization;

namespace BlazorCalculator.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            var cultureInfo = new CultureInfo("pl-PL");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            await builder.Build().RunAsync();
        }
    }
}
