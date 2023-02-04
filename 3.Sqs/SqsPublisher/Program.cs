
using System.Text.Json;
using Amazon.SQS;
using Amazon.SQS.Model;
using SqsPublisher;

var sqsClient = new AmazonSQSClient();

var customer = new CustomerCreated
{
  Id  = Guid.NewGuid(),
  Email = "skeith@skesoft.co.ug",
  FullName = "Ssewannonda Keith Edwin",
  DateOfBirth = new DateTime(1991, 12, 1),
  GithubUsername = "edcsu"
};

var queueUrlResponse = await sqsClient.GetQueueUrlAsync("customers");

var sendMessageRequest = new SendMessageRequest
{
  QueueUrl = queueUrlResponse.QueueUrl,
  MessageBody = JsonSerializer.Serialize(customer),
  MessageAttributes = new Dictionary<string, MessageAttributeValue>
  {
    {
      "MessageType", new MessageAttributeValue
      {
        DataType = "String",
        StringValue = nameof(CustomerCreated)
      }
    }
  }
};

var response = await sqsClient.SendMessageAsync(sendMessageRequest);

Console.WriteLine();