using Amazon.SQS;
using Customer.Consumer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<QueueSettings>(builder.Configuration.GetSection(QueueSettings.Key));

builder.Services.AddSingleton<IAmazonSQS, AmazonSQSClient>();

builder.Services.AddHostedService<QueueConsumerService>();

var app = builder.Build();

app.Run();