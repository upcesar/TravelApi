namespace TravelManagement.Domain.ValueObjects;

public class Passport
{
    public string Number { get; init; }
    public string FullName { get; init; }
    public DateTime IssueDate { get; init; }
    public DateTime ExpirationDate { get; init; }

    public Passport(string number, string fullName, DateTime issueDate, DateTime expirationDate)
    {
        Number = number;
        FullName = fullName;
        IssueDate = issueDate;
        ExpirationDate = expirationDate;
    }
}