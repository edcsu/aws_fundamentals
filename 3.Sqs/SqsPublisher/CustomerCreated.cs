namespace SqsPublisher;

public class CustomerCreated
{
    public  Guid Id { get; init; }
    public string FullName { get; init; } = default!;
    public  string Email { get; init; } = default!;
    public  string GithubUsername { get; init; } = default!;
    public  DateTime DateOfBirth { get; init; }
}