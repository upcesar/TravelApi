namespace TravelManagement.Domain.Common;

public class Entity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTimeOffset CreatedAt { get; init; } = DateTime.Now;
    public DateTimeOffset? UpdatedAt { get; init; }
}
