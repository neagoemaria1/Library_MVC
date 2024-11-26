﻿using Library.Enums;
using Microsoft.AspNetCore.Identity;

namespace Library.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            // Seed Roles
            if (!await roleManager.RoleExistsAsync(Roles.Admin.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            }
            if (!await roleManager.RoleExistsAsync(Roles.Basic.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
            }
        }
    }
}