using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
  public class Usuario
  {
    public int Idusuario { get; set; }
    [Required]
    public int Idrol { get; set; }
    [Required]
    [StringLength(64, MinimumLength = 3, ErrorMessage = "El nombre no debe tener mas de 64 caracteres y menos de 3 caracteres")]
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public byte[] Password_hash { get; set; }
    [Required]
    public byte[] Password_salt { get; set; }
    public bool Estado { get; set; }

    [ForeignKey("Idrol")]
    public Rol Rol { get; set; }

    public ICollection<Servicio> Servicios { get; set; }
    public ICollection<Reserva> Reservas { get; set; }
  }
}
