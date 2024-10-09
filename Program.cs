using ITFPatternTraining;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;



var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddRadzenComponents();
builder.Services.AddRadzenQueryStringThemeService();

builder.Services.AddSingleton<ScoreToolState>();
builder.Services.AddSingleton<PatternSelectorState>();
builder.Services.AddSingleton<SparringScoreToolState>();

await builder.Build().RunAsync();


