
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Users.Api.Models;

public class Profile
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? IdentityId { get; set; }

    [Required]
    public AuthProvider Provider { get; set; }

    [JsonIgnore]
    public virtual Account? Account { get; set; }
}


public enum AuthProvider
{
    local,
    GOOGLE,
    Github,
    Auth0
}