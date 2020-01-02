using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
  public class Rol
  {
    public int Idrol { get; set; }

    [Required]
    [StringLength(64, MinimumLength = 3, ErrorMessage = "El nombre no debe tener mas de 64 caracteres y menos de 3 caracteres")]
    public string Nombre { get; set; }

    [StringLength(256)]
    public string Descripcion { get; set; }

    public bool Estado { get; set; }
  }
}
