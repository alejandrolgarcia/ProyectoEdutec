using System;
using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datos
{
  public class ReservaMap : IEntityTypeConfiguration<Reserva>
  {
    public void Configure(EntityTypeBuilder<Reserva> builder)
    {
      builder.ToTable("reserva")
        .HasKey( r => r.Idreserva );
    }
  }
}
