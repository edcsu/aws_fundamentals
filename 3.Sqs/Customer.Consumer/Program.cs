using Amazon.SQS;
using Customer.Consumer;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.Configure<QueueSettings>(builder.Configuration.GetSection(QueueSettings.Key));

builder.Services.AddSingleton<IAmazonSQS, AmazonSQSClient>();

builder.Services.AddHostedService<QueueConsumerService>();

builder.Services.AddMediatR(typeof(Program));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.Logger.LogInformation("Starting the app");

app.Run();