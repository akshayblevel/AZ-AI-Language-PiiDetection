using AZ_AI_Language_PiiDetection.Interfaces;
using AZ_AI_Language_PiiDetection.Services;
using Azure;
using Azure.AI.TextAnalytics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var configSection = builder.Configuration.GetSection("AzureTextAnalytics");
string endpoint = configSection["Endpoint"] ?? throw new InvalidOperationException("Missing endpoint");
string apiKey = configSection["ApiKey"] ?? throw new InvalidOperationException("Missing api key");

builder.Services.AddSingleton(sp => new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey)));
builder.Services.AddScoped<IAnalysisService, AnalysisService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
