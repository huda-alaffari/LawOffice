using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

public class PermissionService
{
    private readonly AuthenticationStateProvider _authStateProvider;

    public PermissionService(AuthenticationStateProvider authStateProvider)
    {
        _authStateProvider = authStateProvider;
    }

    public async Task<bool> Has(string permissionName)
    {
        var authState = await _authStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity is not { IsAuthenticated: true }) return false;

        // permission claims stored as "permission"
        return user.Claims.Any(c => c.Type == "permission" && c.Value == permissionName);
    }
}
