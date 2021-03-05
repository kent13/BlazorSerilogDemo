using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using BlazorSerilogDemo.Services;
using Serilog.Events;
using Serilog.Core;

namespace BlazorSerilogDemo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<LoggerService>();

            var host = builder.Build();
            var loggerService = host.Services.GetService<LoggerService>();
            loggerService.LevelSwitch.MinimumLevel = LogEventLevel.Warning;
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(loggerService.LevelSwitch)
                .Enrich.WithProperty("InstanceId", Guid.NewGuid().ToString("n"))
                .WriteTo.LoggerSink(host.Services.GetRequiredService<LoggerService>()) // the Blazor custome cachs log
                .WriteTo.BrowserConsole() // browser console
                .WriteTo.Debug()  // visual studio debug window
                .CreateLogger();

            await host.RunAsync();

            Log.Information("Hello, browser!");
        }
    }
}
