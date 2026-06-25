using Microsoft.EntityFrameworkCore;
using ProdutoAPI.Data;
using ProdutoAPI.DTOs;
using ProdutoAPI.Models;

namespace ProdutoAPI.Services;

public class ProdutoService
{
    private readonly AppDbContext _context;

    public ProdutoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProdutoResumoDTO>> ListarResumo()
    {
        return await _context.Produtos
            .Include(p => p.Categoria)
            .Select(p => new ProdutoResumoDTO
            {
                Nome = p.Nome,
                Categoria = p.Categoria!.Nome
            })
            .ToListAsync();
    }

    public async Task<bool> AtualizarProduto(int id, ProdutoUpdateDTO dto)
    {
        var produto = await _context.Produtos.FindAsync(id);

        if (produto == null)
        {
            return false;
        }

        produto.Nome = dto.Nome;
        produto.Preco = dto.Preco;
        produto.Estoque = dto.Estoque;
        produto.CategoriaId = dto.CategoriaId;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<Produto> CriarProduto(ProdutoCreateDTO dto)
    {
        var produto = new Produto
        {
            Nome = dto.Nome,
            Preco = dto.Preco,
            Estoque = dto.Estoque,
            CategoriaId = dto.CategoriaId
        };

        _context.Produtos.Add(produto);

        await _context.SaveChangesAsync();

        return produto;
    }

   
}