using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiServicios.Models.Servicio
{
  public class CreateViewModel
  {
    [Required]
    public int Idcategoria { get; set; }
    [Required]
    public int Idusuario { get; set; }
    [Required]
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }

    [Required]
    public List<DetalleHorarioViewModel> DetalleHorario { get; set; }

  }
}
