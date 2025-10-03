using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Antiforgery;
using UniversityRegistration.Data;
using UniversityRegistration.Models;
using AcademicEnrollment.Components;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default")
                       ?? throw new InvalidOperationException("Connection string 'Default' not found.");

builder.Services.AddDbContext<UniversityRegistrationContext>(options =>
    options.UseSqlServer(connectionString));

// Add Identity services
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => 
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
.AddEntityFrameworkStores<UniversityRegistrationContext>()
.AddDefaultTokenProviders();

// Configure Identity paths
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/login";
    options.LogoutPath = "/logout";
    options.AccessDeniedPath = "/login";
    options.ReturnUrlParameter = "ReturnUrl";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromHours(8);
});

// Configure antiforgery
builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "X-CSRF-TOKEN";
    options.SuppressXFrameOptionsHeader = false;
});

// Add API services
builder.Services.AddControllers();

// Add Blazor services
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Seed database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<UniversityRegistrationContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    await SeedData.SeedAsync(context, userManager);
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Add authentication middleware
app.UseAuthentication();
app.UseAuthorization();

// API endpoints
app.MapControllers();

// Blazor endpoints
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Basic API endpoints for testing
app.MapGet("/api/health", () => "API is running");

// Minimal API endpoint for login (handles cookie issuing on HTTP response)
app.MapPost("/auth/login", async (
    HttpContext http,
    [FromForm] string username,
    [FromForm] string password,
    [FromForm] bool rememberMe,
    [FromForm] string? returnUrl,
    SignInManager<IdentityUser> signInManager,
    UserManager<IdentityUser> userManager) =>
{
    IdentityUser? user = null;
    if (!string.IsNullOrWhiteSpace(username))
    {
        if (username.Contains('@'))
        {
            user = await userManager.FindByEmailAsync(username);
        }
        user ??= await userManager.FindByNameAsync(username);
    }

    if (user is null)
    {
        return Results.Redirect("/login?error=invalid");
    }

    var result = await signInManager.PasswordSignInAsync(user.UserName!, password, rememberMe, lockoutOnFailure: true);
    if (result.Succeeded)
    {
        var target = !string.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl) ? returnUrl! : "/";
        return Results.Redirect(target);
    }

    if (result.RequiresTwoFactor)
        return Results.Redirect("/login?error=2fa");
    if (result.IsLockedOut)
        return Results.Redirect("/login?error=locked");

    return Results.Redirect("/login?error=invalid");

    static bool IsLocalUrl(string url)
    {
        if (string.IsNullOrEmpty(url)) return false;
        if (!url.StartsWith('/')) return false;
        if (url.StartsWith("//") || url.StartsWith("/\\")) return false;
        return true;
    }
})
.AllowAnonymous()
.DisableAntiforgery();

// Minimal API endpoint for logout
app.MapPost("/auth/logout", async (SignInManager<IdentityUser> signInManager) =>
{
    await signInManager.SignOutAsync();
    return Results.Redirect("/login");
})
.AllowAnonymous()
.DisableAntiforgery();

app.MapGet("/auth/logout", async (SignInManager<IdentityUser> signInManager) =>
{
    await signInManager.SignOutAsync();
    return Results.Redirect("/login");
})
.AllowAnonymous();

app.Run();