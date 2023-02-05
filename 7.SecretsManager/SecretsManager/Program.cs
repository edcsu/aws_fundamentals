
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

var secretsManagerClient = new AmazonSecretsManagerClient();

/*var listSecretVersionIdsRequest = new ListSecretVersionIdsRequest
{
    SecretId = "ApiKey",
    IncludeDeprecated = true
};

var resposnse = await secretsManagerClient.ListSecretVersionIdsAsync(listSecretVersionIdsRequest);*/

var request = new GetSecretValueRequest
{
    SecretId = "ApiKey",
    // VersionStage = "AWSCURRENT"
};

var response = await  secretsManagerClient.GetSecretValueAsync(request);

Console.WriteLine(response.SecretString);


var describeRequest = new DescribeSecretRequest
{
    SecretId = "ApiKey"
};

var describeResponse = await secretsManagerClient.DescribeSecretAsync(describeRequest);