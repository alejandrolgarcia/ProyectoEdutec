using System;
using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datos
{
  public class CategoriaMap : IEntityTypeConfiguration<Categoria>
  {
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
      // Mapear la tabla Categoria en la base de datos
      builder.ToTable("categoria")
        .HasKey(c => c.Idcategoria);
    }
  }
}
