using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace student_api;
[Table("student")]
public class Student
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    [Required]
    public string? Address { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? ContactNumber { get; set; }
}
