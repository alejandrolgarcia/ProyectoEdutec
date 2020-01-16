using System;
using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datos
{
  public class HorarioMap : IEntityTypeConfiguration<Horario>
  {
    public void Configure(EntityTypeBuilder<Horario> builder)
    {
      builder.ToTable("horario")
        .HasKey( h => h.Idhorario );
    }
  }
}
