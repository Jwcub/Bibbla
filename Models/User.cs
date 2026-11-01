using System;

namespace eLibrary.Models;

// Olika användare i systemet (inget stöd för teacher implementerat)
public enum UserRole
    {
        pupil,
        teacher,
        admin
    }

// Klass för användare
public class User
{
    public int UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public UserRole Role { get; set; } = UserRole.pupil;
    public int? Grade { get; set; }
    public string? ClassLetter { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
}
