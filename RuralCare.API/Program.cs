using RuralCare.API.Services;
using RuralCare.AI.Orchestrator.Clients;
using RuralCare.AI.Orchestrator.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITriageService, TriageService>();
builder.Services.AddScoped<IGemmaOrchestrator, GemmaOrchestrator>();
builder.Services.AddHttpClient<Gemma4Client>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();