using FluentValidation.Results;

namespace TravelManagement.Domain.Common;

public class Entity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime CreateAt { get; init; }
    public DateTime UpdatedAt { get; init; }
    public virtual bool IsValid => true;
    public ValidationResult ValidationResult { get; protected set; } = new ValidationResult();
}
