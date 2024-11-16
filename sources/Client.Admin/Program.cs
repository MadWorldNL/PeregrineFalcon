using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MadWorldNL.PeregrineFalcon;
using MadWorldNL.PeregrineFalcon.Domain.Settings;
using Microsoft.Extensions.Options;
using Server.Controllers.Grpc;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.Configure<ApiSettings>(
    builder.Configuration.GetSection(ApiSettings.Key));

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton(services => 
{ 
    var httpClient = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler()));
    var baseUri = services.GetRequiredService<IOptions<ApiSettings>>().Value.Endpoint; 
    var channel = GrpcChannel.ForAddress(baseUri, new GrpcChannelOptions { HttpClient = httpClient });
    return new HealthService.HealthServiceClient(channel);
});

await builder.Build().RunAsync();