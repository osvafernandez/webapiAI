using GroqSharp;
using GroqSharp.Models;

namespace webapiAI.Common;
public class GroqRequestBuilder
{
    public static IGroqClient BuildClient(string apiKey, 
        string apiModel = "moonshotai/kimi-k2-instruct-0905",
        int maxTokens = 4096, 
        string apiUri ="https://api.groq.com/openai/v1/chat/completions")
    {
        return new GroqClient(apiKey, apiModel)
            .SetTemperature(0.6)
            .SetMaxTokens(maxTokens)
            .SetTopP(1)
            .SetStop("NONE")
            .SetStructuredRetryPolicy(5)
            .SetBaseUrl(apiUri);
    }
}