using System;
using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datos
{
  public class RolMap : IEntityTypeConfiguration<Rol>
  {
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
      builder.ToTable("rol")
        .HasKey(r => r.Idrol);
    }
  }
}
