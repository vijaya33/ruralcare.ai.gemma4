using RuralCare.AI.Orchestrator.Clients;
using RuralCare.AI.Orchestrator.Services;
using RuralCare.API.Services;
using RuralCare.Web.Components;
using RuralCare.Web.Services;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<ITriageService, TriageService>();
//builder.Services.AddScoped<RuralCare.AI.Orchestrator.Services.IGemmaOrchestrator, RuralCare.AI.Orchestrator.Services.GemmaOrchestrator>();
//builder.Services.AddHttpClient<Gemma4Client>();

//var app = builder.Build();

//app.UseSwagger();
//app.UseSwaggerUI();

//app.MapControllers();
//app.Run();


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7234/") // replace with your API HTTPS port
});

builder.Services.AddScoped<TriageApiService>();
builder.Services.AddScoped<RuralCare.AI.Orchestrator.Services.IGemmaOrchestrator, RuralCare.AI.Orchestrator.Services.GemmaOrchestrator>();
builder.Services.AddHttpClient<Gemma4Client>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();