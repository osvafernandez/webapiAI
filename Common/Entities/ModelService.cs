namespace webapiAI.Common.Entities;
public class ModelService
{
    public string Uri { get; set; } = "https://api.groq.com/openai/v1/chat/completions";

    public string Model { get; set; } = "moonshotai/kimi-k2-instruct-0905";

    public required string ApiKey { get; set; }

    public int MaxTokens { get; set; } = 4096;
}