using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
  public class Horario
  {
    public int Idhorario { get; set; }
    public int Idservicio { get; set; }
    public DateTime Hora_inicio { get; set; }
    public DateTime Hora_final { get; set; }
    public bool Estado { get; set; }

    [ForeignKey("Idservicio")]
    public Servicio Servicio { get; set; }
  }
}
