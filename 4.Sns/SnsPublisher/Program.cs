using System.Text.Json;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using SnsPublisher;

var customer = new CustomerCreated
{
    Id = Guid.NewGuid(),
    Email = "skeith@skesoft.co.ug",
    FullName = "Ssewannonda Keith Edwin",
    DateOfBirth = new DateTime(1991, 12, 1),
    GithubUsername = "edcsu"
};

var snsClient = new AmazonSimpleNotificationServiceClient();

var topicArnResponse = await snsClient.FindTopicAsync("customers");

var publishRequest = new PublishRequest
{
    TopicArn = topicArnResponse.TopicArn,
    Message = JsonSerializer.Serialize(customer),
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

var response = await snsClient.PublishAsync(publishRequest);

/*
 // upto 10 batch entries
 var publishBatchRequest = new PublishBatchRequest
{
    PublishBatchRequestEntries = new List<PublishBatchRequestEntry>
    {
        new PublishBatchRequestEntry
        {
            Id = Guid.NewGuid().ToString(),
            Message = JsonSerializer.Serialize(customer),
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
        }
    },
    TopicArn = topicArnResponse.TopicArn
};

var batchResponse = await snsClient.PublishBatchAsync(publishBatchRequest);*/