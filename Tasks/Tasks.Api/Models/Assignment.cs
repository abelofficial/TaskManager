
using System.ComponentModel.DataAnnotations;

namespace Tasks.Api.Models;

public class Assignment
{
    [Key]
    [Required]
    public int Id { get; set; }


    [Required]
    public AssignmentTypes Type { get; set; }

    [Required]
    public virtual User? Owner { get; set; }

}

public enum AssignmentTypes
{
    Board,
    ToDo,
}