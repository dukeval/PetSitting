using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedAccounts(DataContext context)
        {
            if (await context.Accounts.AnyAsync()) return;

            var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

            foreach (var acct in users)
            {
                using var hmac = new HMACSHA512();
                acct.UserName = acct.UserName.ToLower();
                acct.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("P@$$W0rd"));
                acct.PasswordSalt = hmac.Key;
                acct.Email = $"{acct.UserName}@test.com";
                acct.LastActive = acct.LastActive;

                context.Accounts.Add(acct);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedUsers(DataContext context)
        {
            if (await context.Users.AnyAsync()) return;

            var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<User>>(userData);

            foreach (var user in users)
            {
                context.Users.Add(user);

            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedSitters(DataContext context)
        {
            if (await context.Sitters.AnyAsync()) return;

            var sitterData = await File.ReadAllTextAsync("Data/SitterSeedData.json");
            var sitters = JsonSerializer.Deserialize<List<Sitter>>(sitterData);

            foreach (var sitter in sitters)
            {
                context.Sitters.Add(sitter);
            }

            await context.SaveChangesAsync();
        }
    }
}