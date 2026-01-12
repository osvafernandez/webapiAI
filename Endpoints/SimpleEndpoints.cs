using GroqSharp;
using GroqSharp.Models;
using Microsoft.AspNetCore.Mvc;
using webapiAI.Common;
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

      group.MapPost("/chat", async ([FromBody] PromptDto promptDto, ServiceBalancer balancer) =>
      {
         var node = balancer.GetNext();
         IGroqClient groqClient = GroqRequestBuilder.BuildClient(node.ApiKey, node.Model, node.MaxTokens, node.Uri);
         var response = await groqClient.CreateChatCompletionAsync(
            new Message { Role = MessageRoleType.User, Content = $"{promptDto.Prompt}" });
         var responseText = response?.ToString() ?? string.Empty;

          // If the model returned escaped newlines like "\n", convert them to real line breaks
         responseText = ResponseStringParser.ParseResponse(responseText);

         return responseText != null ? Results.Text(responseText, "text/plain") : Results.NotFound();
      });
      return app;

   }

}
