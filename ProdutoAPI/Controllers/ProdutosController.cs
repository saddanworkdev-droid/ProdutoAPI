using Microsoft.AspNetCore.Authorization;
using ProdutoAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdutoAPI.Data;
using ProdutoAPI.Models;
using ProdutoAPI.DTOs;

namespace ProdutoAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IProdutoService _produtoService;

    public ProdutosController(AppDbContext context, IProdutoService produtoService)
    {
        _context = context;
        _produtoService = produtoService;
    }
        

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
    {
        return await _context.Produtos
            .Include(p => p.Categoria)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Produto>> GetProduto(int id)
    {
        var produto = await _context.Produtos
            .Include(p => p.Categoria)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (produto == null)
        {
            return NotFound();
        }

        return produto;
    }

    [HttpGet("AcimaDe100")]
    public async Task<ActionResult<IEnumerable<Produto>>> GetProdutosAcimaDe100()
    {
        return await _context.Produtos
            .Where(p => p.Preco > 100)
            .Include(p => p.Categoria)
            .ToListAsync();
    }

    [HttpGet("BuscarPorNome/{nome}")]
    public async Task<ActionResult<IEnumerable<Produto>>> BuscarPorNome(string nome)
    {
        return await _context.Produtos
            .Where(p => p.Nome.Contains(nome))
            .Include(p => p.Categoria)
            .ToListAsync();
    }

    [HttpGet("OrdenadosPorNome")]
    public async Task<ActionResult<IEnumerable<Produto>>> GetProdutosOrdenados()
    {
        return await _context.Produtos
            .Include(p => p.Categoria)
            .OrderBy(p => p.Nome)
            .ToListAsync();
    }

    [HttpGet("PrimeiroPorNome/{nome}")]
    public async Task<ActionResult<Produto>> PrimeiroPorNome(string nome)
    {
        var produto = await _context.Produtos
            .Include(p => p.Categoria)
            .FirstOrDefaultAsync(p => p.Nome.Contains(nome));

        if (produto == null)
        {
            return NotFound();
        }

        return produto;
    }

    [HttpGet("Quantidade")]
    public async Task<ActionResult<int>> QuantidadeProdutos()
    {
        return await _context.Produtos.CountAsync();
    }

    [HttpGet("Existe/{nome}")]
    public async Task<ActionResult<bool>> ExisteProduto(string nome)
    {
        return await _context.Produtos
            .AnyAsync(p => p.Nome == nome);
    }

    [HttpGet("Resumo")]
    public async Task<IActionResult> ResumoProdutos()
    {
        var produtos = await _produtoService.ListarResumo();

        return Ok(produtos);
    }

    [HttpGet("Paginado")]
    public async Task<IActionResult> ProdutosPaginados(
    int page = 1,
    int pageSize = 5,
    string? nome = null,
    string? ordenarPor = null,
    bool desc = false)
    {
        var produtos = await _produtoService.ListarPaginado(
            page,
            pageSize,
            nome,
            ordenarPor,
            desc
        );

        return Ok(produtos);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduto(int id, ProdutoUpdateDTO dto)
    {
        var atualizado = await _produtoService.AtualizarProduto(id, dto);

        if (!atualizado)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduto(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);

        if (produto == null)
        {
            return NotFound();
        }

        _context.Produtos.Remove(produto);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Produto>> PostProduto(ProdutoCreateDTO dto)
    {
        var produto = await _produtoService.CriarProduto(dto);

        return CreatedAtAction(
            nameof(GetProduto),
            new { id = produto.Id },
            produto
        );
    }
}