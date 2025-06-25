

using System.ComponentModel.DataAnnotations;

namespace TodoLibrary.Models;

public class TodoModel
{
    public int Id { get; set; }
    [MaxLength(500)]
    public string? Task { get; set; }
    public int AssignedTo { get; set; }
    public bool IsComplete { get; set; }
}
