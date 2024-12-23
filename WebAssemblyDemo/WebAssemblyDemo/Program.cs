using WebAssemblyDemo.Client;
using WebAssemblyDemo.Client.Models;
using WebAssemblyDemo.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSingleton<ContainerStorage>();

builder.Services.AddHttpClient("ServersApi", client =>
{
    client.BaseAddress = new Uri("https://webassemblydemo-3a373-default-rtdb.europe-west1.firebasedatabase.app/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddTransient<IServersRepository, ServersApiRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(WebAssemblyDemo.Client._Imports).Assembly);

app.Run();
