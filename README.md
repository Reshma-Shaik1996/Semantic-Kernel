# Semantic Kernel OpenAI Practice

This workspace contains a .NET 8 console app:

The app creates a Semantic Kernel, registers OpenAI chat completion, stores a `ChatHistory`, and runs an interactive chat loop.

## Project

- `SemanticKernelOpenAIConsoleApp/` - console app
- `net.sln` - solution containing the project

## Setup

Set your OpenAI API key before running the app:

```bash
export OPENAI_API_KEY="your-api-key"
```

Optional: choose a model. If omitted, the app uses `gpt-4o-mini`.

```bash
export OPENAI_MODEL_ID="gpt-4o-mini"
```

## Run

```bash
dotnet run --project SemanticKernelOpenAIConsoleApp/SemanticKernelOpenAIConsoleApp.csproj
```

Type `exit` to quit the chat.

## Practice Ideas

1. Change the system prompt in `Program.cs` and observe how the assistant style changes.
2. Add a `/reset` command that clears `ChatHistory` and starts a fresh conversation.
3. Add a `/model` command that prints the active model name.
4. Create a simple plugin method, for example a function that returns the current date, and call it from the chat flow.
5. Compare short prompts versus detailed prompts and inspect how the chat history affects later answers.
