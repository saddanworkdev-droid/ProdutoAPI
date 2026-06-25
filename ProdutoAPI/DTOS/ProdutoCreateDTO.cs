using System.ComponentModel.DataAnnotations;

namespace ProdutoAPI.DTOs;

public class ProdutoCreateDTO
{
    [Required]
    public string Nome { get; set; } = string.Empty;

    [Range(0.01, 999999)]
    public decimal Preco { get; set; }

    [Range(0, 999999)]
    public int Estoque { get; set; }

    public int CategoriaId { get; set; }
}