using GroqSharp;
using GroqSharp.Models;
using Microsoft.AspNetCore.Mvc;
using webapiAI.Dtos;

namespace webapiAI.Endpoints;

public static class SimpleEndpoints
{
   public static IEndpointRouteBuilder MapSimpleEndpoints(this IEndpointRouteBuilder app)
   {

      var group = app.MapGroup("/status");

      group.MapGet("/", async () =>
      {
         return Results.Ok(new { Status = "API is running", Timestamp = DateTime.UtcNow });
      });

      group.MapPost("/chat", async ([FromBody] PromptDto promptDto) =>
      {
         DotNetEnv.Env.Load();
         var apiKey = Environment.GetEnvironmentVariable("GROK_API_KEY")
            ?? throw new InvalidOperationException("GROK_API_KEY (or GROQ_API_KEY) was not found in environment variables or .env.");
         var apiModel = "moonshotai/kimi-k2-instruct-0905";
         IGroqClient groqClient = new GroqClient(apiKey, apiModel)
            .SetTemperature(0.6)
            .SetMaxTokens(4096)
            .SetTopP(1)
            .SetStop("NONE")
            .SetStructuredRetryPolicy(5);
            // .SetBaseUrl(""); // luego probar con otro url para servicios distintos
         var response = await groqClient.CreateChatCompletionAsync(
            new Message { Role = MessageRoleType.User, Content = $"{promptDto.Prompt}" });
         Console.WriteLine(response);
         var responseText = response?.ToString() ?? string.Empty;

          // If the model returned escaped newlines like "\n", convert them to real line breaks
         responseText = responseText
            .Replace("\\r\\n", "\n")
            .Replace("\\n", "\n");

         return responseText != null ? Results.Ok(responseText) : Results.NotFound();
      });
      return app;
   }
}
