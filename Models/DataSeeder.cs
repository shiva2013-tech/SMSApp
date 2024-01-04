using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SMSApp.Models
{
    public static class DataSeeder
    {
        private static readonly Random random = new Random();
        public static void SeedAdminData(ModelBuilder modelBuilder)
        {
            // You can customize the default admin credentials here
            var adminUsername = "admin@example.com";
            var adminPassword = "Default@123"; // Make sure to use a strong password

            var admin = new Admin
            {
                AdminId = GenerateRandomAlphanumeric(5),
                Username = adminUsername,
                PasswordHash = HashPassword(adminPassword)
            };

            modelBuilder.Entity<Admin>().HasData(admin);
        }

        private static string HashPassword(string password)
        {
            // Implement a secure password hashing algorithm (e.g., using bcrypt or other secure hashing algorithm)
            // For simplicity, you can use Identity's PasswordHasher for this demonstration
            var passwordHasher = new PasswordHasher<Admin>();
            return passwordHasher.HashPassword(null, password);
        }

        public static string GenerateRandomAlphanumeric(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

}
