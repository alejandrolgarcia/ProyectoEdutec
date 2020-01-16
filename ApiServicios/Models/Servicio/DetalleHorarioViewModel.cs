using System;
namespace ApiServicios.Models.Servicio
{
  public class DetalleHorarioViewModel
  {
    public int Idservicio { get; set; }
    public DateTime Hora_inicio { get; set; }
    public DateTime Hora_final { get; set; }
  }
}
