using System.ComponentModel.DataAnnotations;

namespace CollabManage.Models;

public class Employee
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Cargo { get; set; }
    [Required]
    public string Departamento { get; set; }
}
