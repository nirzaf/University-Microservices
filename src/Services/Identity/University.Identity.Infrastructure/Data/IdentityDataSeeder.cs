using BuildingBlocks.Persistence;
using Microsoft.AspNetCore.Identity;
using University.Identity.Core.Core;
using University.Identity.Core.Models;

namespace University.Identity.Infrastructure.Data;

public class IdentityDataSeeder : IDataSeeder
{
    private readonly RoleManager<IdentityRole<int>> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public IdentityDataSeeder(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task SeedAllAsync()
    {
        await SeedRoles();
        await SeedUsers();
    }

    private async Task SeedRoles()
    {
        if (await _roleManager.RoleExistsAsync(Constants.Role.Admin) == false)
            await _roleManager.CreateAsync(new IdentityRole<int>(Constants.Role.Admin));

        if (await _roleManager.RoleExistsAsync(Constants.Role.User) == false)
            await _roleManager.CreateAsync(new IdentityRole<int>(Constants.Role.User));
    }

    private async Task SeedUsers()
    {
        if (await _userManager.FindByNameAsync("meysamh") == null)
        {
            var user = new ApplicationUser
            {
                FirstName = "Meysam",
                LastName = "Hadeli",
                UserName = "meysamh",
                Email = "meysam@test.com"
            };

            var result = await _userManager.CreateAsync(user, "Admin@123456");

            if (result.Succeeded)
                await _userManager.AddToRoleAsync(user, Constants.Role.Admin);
        }

        if (await _userManager.FindByNameAsync("meysamh2") == null)
        {
            var user = new ApplicationUser
            {
                FirstName = "Meysam",
                LastName = "Hadeli",
                UserName = "meysamh2",
                Email = "meysam2@test.com"
            };

            var result = await _userManager.CreateAsync(user, "User@123456");

            if (result.Succeeded)
                await _userManager.AddToRoleAsync(user, Constants.Role.User);
        }
    }
}