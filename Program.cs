using Scalar.AspNetCore;
using webapiAI.Common;
using webapiAI.Endpoints;
using webapiAI.Common.Entities;

DotNetEnv.Env.Load();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var services = new List<ModelService>
{
    new ModelService
    {
        Uri = "https://openrouter.ai/api/v1/chat/completions",
        Model = "openai/gpt-5.2",
        ApiKey = Environment.GetEnvironmentVariable("OPEN_ROUTER_KEY") ?? 
            builder.Configuration["OPEN_ROUTER_KEY"] ?? throw new InvalidOperationException("OPEN_ROUTER_KEY was not found in environment variables or .env."),
        MaxTokens = 2857
    },
    new ModelService
    {
        Uri = "https://api.groq.com/openai/v1/chat/completions",
        Model = "moonshotai/kimi-k2-instruct-0905",
        ApiKey = Environment.GetEnvironmentVariable("GROK_API_KEY") ?? builder.Configuration["GROQ_API_KEY"]
            ?? throw new InvalidOperationException("GROK_API_KEY (or GROQ_API_KEY) was not found in environment variables or .env."),
        MaxTokens = 4096
    },
    new ModelService
    {
        Uri = "https://api.cerebras.ai/v1/chat/completions",
        Model = "llama-3.3-70b",
        ApiKey = Environment.GetEnvironmentVariable("CEREBRAS_API_KEY") ?? 
            builder.Configuration["CEREBRAS_API_KEY"] ?? throw new InvalidOperationException("CEREBRAS_API_KEY was not found in environment variables or .env."),
        MaxTokens = 8192
    },
    new ModelService
    {
        Uri = "https://api.groq.com/openai/v1/chat/completions",
        Model = "openai/gpt-oss-120b",
        ApiKey = Environment.GetEnvironmentVariable("GROQ_OSVANARANJO_API_KEY") ?? 
            builder.Configuration["GROQ_OSVANARANJO_API_KEY"] ?? throw new InvalidOperationException("GROQ_OSVANARANJO_API_KEY was not found in environment variables or .env."),
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
