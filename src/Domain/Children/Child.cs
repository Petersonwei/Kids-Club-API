using SharedKernel;

namespace Domain.Children;

public sealed class Child : Entity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsCheckedIn { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CheckedInAt { get; set; }
}
