using ProdutoAPI.DTOs;
using ProdutoAPI.Models;

namespace ProdutoAPI.Interfaces;

public interface IProdutoService
{
    Task<List<ProdutoResumoDTO>> ListarResumo();

    Task<List<ProdutoResumoDTO>> ListarPaginado(
        int page,
        int pageSize,
        string? nome,
        string? ordenarPor,
        bool desc);

    Task<bool> AtualizarProduto(int id, ProdutoUpdateDTO dto);

    Task<Produto> CriarProduto(ProdutoCreateDTO dto);
}