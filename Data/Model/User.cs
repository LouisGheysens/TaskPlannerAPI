using System.ComponentModel.DataAnnotations;

namespace Data.Model;
public partial class User
{
    public string Username { get; set; } = null!;

    [EmailAddress]
    public string? Email { get; set; } = null!;

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }
}
