using Microsoft.AspNetCore.Authorization;

public class PermissionRequirement : IAuthorizationRequirement
{
    public string PermissionName { get; }

    public PermissionRequirement(string permission)
    {
        PermissionName = permission;
    }
}
