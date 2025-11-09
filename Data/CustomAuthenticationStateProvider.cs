using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal _anonymous = new(new ClaimsIdentity());

    private ClaimsPrincipal _currentUser = null!;

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return Task.FromResult(new AuthenticationState(_currentUser ?? _anonymous));
    }

    public void SignIn(string email)
    {
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, email)
        }, "CustomAuth");

        _currentUser = new ClaimsPrincipal(identity);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public void SignOut()
    {
        _currentUser = _anonymous;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
