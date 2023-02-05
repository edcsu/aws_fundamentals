using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace DotLambda;

public class Function
{
    /// <summary>
    /// A simple function that takes a request and prints it
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public void FunctionHandler(Hello request, ILambdaContext context)
    {
        context.Logger.LogInformation($"Hello from {request.World}");
    }
}

public class Hello
{
    public string World { get; set; } = default!;
}