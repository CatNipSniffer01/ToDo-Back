using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.modells {
    [PrimaryKey("User_Id")]
    public class users {
        [JsonIgnore] public int User_Id { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public int? Acc_CR_D { get; set; }
        public int? Acc_UP_D { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class PasswordHasher
    {
        public static string HashPassword(string Password)
        {
            return BCrypt.Net.BCrypt.HashPassword(Password);
        }

        public static bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedPassword);
        }
    }
}