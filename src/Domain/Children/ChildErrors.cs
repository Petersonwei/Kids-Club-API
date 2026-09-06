using SharedKernel;

namespace Domain.Children;

public static class ChildErrors
{
    public static readonly Error NotFound = Error.NotFound(
        "Child.NotFound",
        "The child with the specified identifier was not found");
}
