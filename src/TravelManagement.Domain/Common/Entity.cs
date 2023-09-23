namespace TravelManagement.Domain.Common;

public class Entity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime CreationDate { get; init; } = DateTime.Now;
}
