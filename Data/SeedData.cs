using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniversityRegistration.Data;
using UniversityRegistration.Models;

namespace UniversityRegistration.Data;

public static class SeedData
{
    public static async Task SeedAsync(UniversityRegistrationContext context, UserManager<IdentityUser> userManager)
    {
        // Apply migrations to ensure database is up to date
        await context.Database.MigrateAsync();

        // Create admin user only
        await CreateAdminUserAsync(context, userManager);
    }

    private static async Task CreateAdminUserAsync(UniversityRegistrationContext context, UserManager<IdentityUser> userManager)
    {
        const string adminUsername = "admin";
        const string adminPassword = "Admin123!";
        const string adminEmail = "admin@university.edu";

        var existingUser = await userManager.FindByNameAsync(adminUsername);
        if (existingUser == null)
        {
            var adminUser = new IdentityUser
            {
                UserName = adminUsername,
                Email = adminEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, adminPassword);
            if (result.Succeeded)
            {
                // Create Admin record
                var admin = new Admin
                {
                    Id = adminUser.Id,
                    Username = adminUsername,
                    FullName = "System Administrator",
                    Email = adminEmail,
                    CreatedAt = DateTime.Now,
                    IsActive = true
                };

                context.Admins.Add(admin);
                await context.SaveChangesAsync();
                
                Console.WriteLine($"Admin user created: {adminUsername}");
            }
            else
            {
                Console.WriteLine($"Failed to create admin user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
        else
        {
            Console.WriteLine("Admin user already exists");
        }
    }
}
