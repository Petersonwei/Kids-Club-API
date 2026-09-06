namespace Application.Children;

public static class ChildCacheKeys
{
    public static string GetChildren(Guid userId) => $"children-{userId}";
}
