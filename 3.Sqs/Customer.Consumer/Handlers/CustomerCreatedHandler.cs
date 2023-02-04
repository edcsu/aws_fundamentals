using Customer.Consumer.Messages;
using MediatR;

namespace Customer.Consumer.Handlers;

public class CustomerCreatedHandler : IRequestHandler<CustomerCreated>
{
    private readonly ILogger<CustomerCreatedHandler> _logger;


    public CustomerCreatedHandler(ILogger<CustomerCreatedHandler> logger)
    {
        _logger = logger;
    }

    public Task<Unit> Handle(CustomerCreated request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(request.Id.ToString());
        _logger.LogInformation(request.FullName);
        _logger.LogInformation(request.Email);
        return Unit.Task;
    }
}