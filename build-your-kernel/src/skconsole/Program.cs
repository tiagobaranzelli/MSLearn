using Microsoft.SemanticKernel;
using DotNetEnv;

Env.Load();

string AZURE_OPENAI_ENDPOINT = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT") ?? throw new ArgumentNullException("AZURE_OPENAI_ENDPOINT");
string AZURE_OPENAI_API_KEY = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY") ?? throw new ArgumentNullException("AZURE_OPENAI_API_KEY");

// Create kernel
var builder = Kernel.CreateBuilder();
builder.AddAzureOpenAIChatCompletion(
    deploymentName: "gpt-35-turbo-16k",
    endpoint: AZURE_OPENAI_ENDPOINT,
    apiKey: AZURE_OPENAI_API_KEY,
    modelId: "gpt-35-turbo-16k" // optional
);
var kernel = builder.Build();


var result = await kernel.InvokePromptAsync(
        "Give me a list of breakfast foods with eggs and cheese and give me answer in portuguese");
Console.WriteLine(result);

Console.ReadLine();