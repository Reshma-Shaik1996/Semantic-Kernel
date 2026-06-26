using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
var modelId = Environment.GetEnvironmentVariable("OPENAI_MODEL_ID") ?? "gpt-4o-mini";

if (string.IsNullOrWhiteSpace(apiKey))
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("OPENAI_API_KEY is not set.");
    Console.ResetColor();
    Console.WriteLine("Set it, then run the app again:");
    Console.WriteLine("  export OPENAI_API_KEY=\"your-api-key\"");
    Console.WriteLine("Optional: export OPENAI_MODEL_ID=\"gpt-4o-mini\"");
    return;
}

var builder = Kernel.CreateBuilder();
builder.AddOpenAIChatCompletion(modelId, apiKey);

var kernel = builder.Build();
var chat = kernel.GetRequiredService<IChatCompletionService>();

var history = new ChatHistory("""
You are a helpful AI assistant for someone practicing Microsoft Semantic Kernel.
Explain answers clearly, keep examples short, and suggest one practical next step.
""");

Console.WriteLine("Semantic Kernel + OpenAI practice chat");
Console.WriteLine($"Model: {modelId}");
Console.WriteLine("Type your message and press Enter. Type 'exit' to quit.");
Console.WriteLine();

while (true)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("You: ");
    Console.ResetColor();

    var userMessage = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(userMessage))
    {
        continue;
    }

    if (userMessage.Equals("exit", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    history.AddUserMessage(userMessage);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("AI: ");
    Console.ResetColor();

    var response = await chat.GetChatMessageContentAsync(history, kernel: kernel);
    var assistantMessage = response.Content ?? string.Empty;

    Console.WriteLine(assistantMessage);
    Console.WriteLine();

    history.AddAssistantMessage(assistantMessage);
}
