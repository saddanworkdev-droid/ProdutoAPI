using System.ComponentModel.DataAnnotations;

namespace ProdutoAPI.DTOs;

public class RegisterDTO
{
    [Required]
    public string Login { get; set; } = string.Empty;

    [Required]
    [MinLength(6)]
    public string Senha { get; set; } = string.Empty;

    public string Role { get; set; } = "User";
}