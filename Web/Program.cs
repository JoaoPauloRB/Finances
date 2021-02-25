using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using BlazorState;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Web.Features;

namespace Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddBlazorState(options =>
            {
                options.Assemblies = new Assembly[]
                {
                    typeof(Program).GetTypeInfo().Assembly
                };
            });

            builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(AuthenticationBehavior<,>));
            builder.Services.AddBlazoredLocalStorage();

            await builder.Build().RunAsync();
        }
    }
}
