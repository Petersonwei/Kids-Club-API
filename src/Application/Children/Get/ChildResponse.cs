namespace Application.Children.Get;

public sealed record ChildResponse(
    Guid Id,
    string Name,
    bool IsCheckedIn,
    DateTime CreatedAt,
    DateTime? CheckedInAt);
