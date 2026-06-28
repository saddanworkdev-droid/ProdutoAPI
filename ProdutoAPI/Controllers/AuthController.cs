using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProdutoAPI.Data;
using ProdutoAPI.DTOs;
using ProdutoAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProdutoAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthController(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost("Register")]
    public IActionResult Register(RegisterDTO dto)
    {
        var usuarioExiste = _context.Usuarios
            .Any(u => u.Login == dto.Login);

        if (usuarioExiste)
        {
            return BadRequest("Usuário já existe.");
        }

        var usuario = new Usuario
        {
            Login = dto.Login,
            SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha),
            Role = dto.Role
        };

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();

        return Ok("Usuário cadastrado com sucesso.");
    }

    [HttpPost("Login")]
    public IActionResult Login(LoginDTO dto)
    {
        var usuario = _context.Usuarios
    .FirstOrDefault(u => u.Login == dto.Login);

        if (usuario == null || !BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.SenhaHash))
        {
            return Unauthorized("Login ou senha inválidos.");
        }

        if (usuario == null)
        {
            return Unauthorized("Login ou senha inválidos.");
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, usuario.Login),
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Role, usuario.Role)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)
        );

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: credentials
        );

        var tokenString = new JwtSecurityTokenHandler()
            .WriteToken(token);

        return Ok(new
        {
            token = tokenString
        });
    }
}