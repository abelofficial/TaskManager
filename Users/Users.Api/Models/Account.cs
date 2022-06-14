
using System.ComponentModel.DataAnnotations;

namespace Users.Api.Models;

public class Account
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public int Email { get; set; }

    [Required]
    public string? Username { get; set; }


    public virtual ICollection<Profile> Profile { get; set; } = new List<Profile>() { new Profile() { Provider = AuthProvider.local } };
}