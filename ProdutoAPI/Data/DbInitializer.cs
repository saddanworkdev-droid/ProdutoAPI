using BCrypt.Net;
using ProdutoAPI.Models;

namespace ProdutoAPI.Data;

public static class DbInitializer
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Usuarios.Any())
        {
            var admin = new Usuario
            {
                Login = "admin",
                SenhaHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                Role = "Admin"
            };

            context.Usuarios.Add(admin);
            context.SaveChanges();
        }
    }
}