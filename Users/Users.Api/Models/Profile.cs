
using System.ComponentModel.DataAnnotations;

namespace Users.Api.Models;

public class Profile
{
    [Key]
    [Required]
    public int Id { get; set; }


    [Required]
    public AuthProvider Provider { get; set; }

    public virtual Account? Account { get; set; }
}


public enum AuthProvider
{
    local,
    GOOGLE,
    Github,
    Auth0
}