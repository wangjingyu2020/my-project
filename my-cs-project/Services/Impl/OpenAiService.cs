using System.Text;
using Azure.AI.OpenAI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using MongoDB.Bson;
using MongoDB.Driver;
using OpenAI.Chat;

namespace my_cs_project.Services.Impl;

public class OpenAiService : IOpenAiService
{
    private readonly ILogger<OpenAiService> _logger;
    private AzureOpenAIClient _openAiClient;


    public OpenAiService(AzureOpenAIClient openAiClient, ILogger<OpenAiService> logger)
    {
        this._openAiClient = openAiClient;
        this._logger = logger;

    }



    public async Task<string> talkWithGPT(string prompt)
    {
        List<ChatMessage> chatHistory = new List<ChatMessage>();
        UserChatMessage userMessage = new UserChatMessage(prompt);
        chatHistory.Add(userMessage);
        ChatClient chatClient = _openAiClient.GetChatClient("gpt-4-32k");
        ChatCompletion completion = await chatClient.CompleteChatAsync(chatHistory);
        return completion.Content[0].Text;

    }
}