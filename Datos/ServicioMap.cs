using System;
using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datos
{
  public class ServicioMap : IEntityTypeConfiguration<Servicio>
  {
    public void Configure(EntityTypeBuilder<Servicio> builder)
    {
      builder.ToTable("servicio")
        .HasKey(s => s.Idservicio);
    }
  }
}
