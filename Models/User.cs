using System;

namespace eLibrary.Models;

public enum UserRole
    {
        pupil,
        teacher,
        admin
    }
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
