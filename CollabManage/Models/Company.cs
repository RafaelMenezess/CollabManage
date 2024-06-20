using System.ComponentModel.DataAnnotations;

namespace CollabManage.Models;

public class Company
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Endereco { get; set; }

    [RegularExpression(@"^\([1-9]{2}\) [2-9][0-9]{3,4}\-[0-9]{4}$", ErrorMessage = "O campo Telefone deve estar no formato (99) 9999-9999 ou (99) 99999-9999")]
    public string Telefone { get; set; }
}
