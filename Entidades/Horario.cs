using System;
namespace Entidades
{
  public class Horario
  {
    public int Idhorario { get; set; }
    public int Idservicio { get; set; }
    public DateTime Hora_inicio { get; set; }
    public DateTime Hora_final { get; set; }
    public bool Estado { get; set; }

    public Servicio Servicio { get; set; }
  }
}
