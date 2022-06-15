
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tasks.Api.Models;

public class User
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string? FullName { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? ProfileImage { get; set; }

    [JsonIgnore]
    public virtual ICollection<Assignment> Assignment { get; set; } = new List<Assignment>();

}