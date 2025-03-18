using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.modells {
    [PrimaryKey("User_Id")]
    public class users {
        public int User_Id { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public string? HashedPassword { get; set; }
        public required string Email { get; set; }
        public int? Acc_CR_D { get; set; }
        public int? Acc_UP_D { get; set; }
    }

    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
        }
    }
}