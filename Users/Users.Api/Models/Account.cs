
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Users.Api.Models;

public class Account
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Username { get; set; }


    [JsonIgnore]
    public virtual ICollection<Profile> Profile { get; set; } = new List<Profile>() { new Profile() { Provider = AuthProvider.local } };
}