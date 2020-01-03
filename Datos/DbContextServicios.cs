using System;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
  public class DbContextServicios : DbContext
  {
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    public DbContextServicios(DbContextOptions<DbContextServicios> options)
      : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfiguration(new CategoriaMap());
      modelBuilder.ApplyConfiguration(new RolMap());
      modelBuilder.ApplyConfiguration(new UsuarioMap());

    }
  }
}
