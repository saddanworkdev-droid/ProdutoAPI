using System.Text.Json.Serialization;

namespace ProdutoAPI.Models;

public class Categoria
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    [JsonIgnore]
    public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}