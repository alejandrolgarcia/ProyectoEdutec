using System;
using System.ComponentModel.DataAnnotations;

namespace ApiServicios.Models.Categoria
{
  public class CreateViewModel
  {
    [Required]
    [StringLength(64)]
    public string Nombre { get; set; }

    [StringLength(128)]
    public string Descripcion { get; set; }
  }
}
