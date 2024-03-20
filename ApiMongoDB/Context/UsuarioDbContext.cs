using ApiMongoDB.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMongoDB.Context;

public class UsuarioDbContext : DbContext
{
    public DbSet<UsuarioTeste> Usuarios { get; set; }
}
