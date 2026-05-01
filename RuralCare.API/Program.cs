using RuralCare.AI.Orchestrator.Clients;
using RuralCare.AI.Orchestrator.Services;
using RuralCare.API.Services;
using RuralCare.API.Services.RuralCare.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITriageService, TriageService>();
builder.Services.AddScoped<IGemmaOrchestrator, GemmaOrchestrator>();
builder.Services.AddHttpClient<Gemma4Client>();
builder.Services.AddHttpClient<XXXHuggingFaceServiceXXX>();
builder.Services.AddHttpClient<HuggingFaceService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();