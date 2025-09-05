using AppBlazor.Client;
using Microsoft.AspNetCore.Components.Web;
using AppBlazor.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<VentaService>();
builder.Services.AddScoped<JefeService>();
builder.Services.AddScoped<SucursalService>();

await builder.Build().RunAsync();
