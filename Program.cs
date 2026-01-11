using Scalar.AspNetCore;
using webapiAI.Common;
using webapiAI.Endpoints;

DotNetEnv.Env.Load();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var services = new List<webapiAI.Common.Entities.ModelService>
{
    new webapiAI.Common.Entities.ModelService
    {
        Uri = "https://api.groq.com/openai/v1/chat/completions",
        Model = "moonshotai/kimi-k2-instruct-0905",
        ApiKey = Environment.GetEnvironmentVariable("GROK_API_KEY")
            ?? throw new InvalidOperationException("GROK_API_KEY (or GROQ_API_KEY) was not found in environment variables or .env."),
        MaxTokens = 4096
    },
    new webapiAI.Common.Entities.ModelService
    {
        Uri = "https://api.cerebras.ai/v1/chat/completions",
        Model = "llama-3.3-70b",
        ApiKey = Environment.GetEnvironmentVariable("CEREBRAS_API_KEY")
            ?? throw new InvalidOperationException("CEREBRAS_API_KEY was not found in environment variables or .env."),
        MaxTokens = 8192
    }
};

builder.Services.AddSingleton(new ServiceBalancer(services));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapApiEndpoints();

app.Run();
