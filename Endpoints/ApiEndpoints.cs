namespace webapiAI.Endpoints;

public static class ApiEndpoints
{
   public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder app)
   {
      var api = app.MapGroup("/api");

      api.MapSimpleEndpoints();

      return app;
   }
}
