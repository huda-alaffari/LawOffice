using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.Data.SqlClient;

public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
            return Task.CompletedTask;

        string connString = "Data Source=LAPTOP-9VFHMEKR\\SQLEXPRESS;Initial Catalog=CaseSystemManagement;Integrated Security=True;TrustServerCertificate=True;";

        using var con = new SqlConnection(connString);
        con.Open();

        using var cmd = new SqlCommand(@"
        SELECT p.PermissionName 
        FROM EmployeePermissions ep
        JOIN Permissions p ON ep.PermissionId = p.Id
        WHERE ep.EmployeeId=@id", con);

        cmd.Parameters.AddWithValue("@id", userId);

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            if (reader.GetString(0) == requirement.PermissionName)
            {
                context.Succeed(requirement);
                break;
            }
        }

        return Task.CompletedTask;
    }
}
