namespace GitHubLike.Modules.RoleModule.Types
{
    [Flags]
    public enum Permissions
    {
        Create = 1,
        Retrieve = 2,
        Update = 4,
        Delete = 8,
    }
}
