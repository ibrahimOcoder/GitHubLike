namespace GitHubLike.Modules.RoleModule.Types
{
    [Flags]
    public enum Permissions
    {
        Create = 1,
        Retrieve,
        Update,
        Delete,
    }
}
