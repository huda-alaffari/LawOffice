
using LowOffice.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<PermissionService>();
// ????? ??????? ?????? ????????
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=.;Database=CaseSystemManagement;Trusted_Connection=True;TrustServerCertificate=True;";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();

// ????? ???? ASP.NET
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

builder.Services.AddSingleton<IAuthorizationHandler, PermissionHandler>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("?????? ????????", p => p.Requirements.Add(new PermissionRequirement("?????? ????????")));
    options.AddPolicy("???????", p => p.Requirements.Add(new PermissionRequirement("???????")));
    options.AddPolicy("?? ??????", p => p.Requirements.Add(new PermissionRequirement("?? ??????")));
    options.AddPolicy("???????", p => p.Requirements.Add(new PermissionRequirement("???????")));
    options.AddPolicy("??????", p => p.Requirements.Add(new PermissionRequirement("??????")));
    options.AddPolicy("????? ????", p => p.Requirements.Add(new PermissionRequirement("????? ????")));
    options.AddPolicy("????? ???????", p => p.Requirements.Add(new PermissionRequirement("????? ???????")));
    options.AddPolicy("??? ??????", p => p.Requirements.Add(new PermissionRequirement("??? ??????")));
    options.AddPolicy("??????? ??????????", p => p.Requirements.Add(new PermissionRequirement("??????? ??????????")));
    options.AddPolicy("??????? ??????", p => p.Requirements.Add(new PermissionRequirement("??????? ??????")));
    options.AddPolicy("????? ?????????", p => p.Requirements.Add(new PermissionRequirement("????? ?????????")));
    options.AddPolicy("???????", p => p.Requirements.Add(new PermissionRequirement("???????")));
    options.AddPolicy("???? ??????", p => p.Requirements.Add(new PermissionRequirement("???? ??????")));
    options.AddPolicy("?????????", p => p.Requirements.Add(new PermissionRequirement("?????????")));

});

