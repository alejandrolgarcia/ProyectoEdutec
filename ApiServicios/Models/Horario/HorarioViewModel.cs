using System;
namespace ApiServicios.Models.Horario
{
  public class HorarioViewModel
  {
    public int Idservicio { get; set; }
    public DateTime Hora_inicio { get; set; }
    public DateTime Hora_final { get; set; }
    public bool Estado { get; set; }
  }
}
