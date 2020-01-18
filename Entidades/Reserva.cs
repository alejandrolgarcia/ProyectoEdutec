using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
  public class Reserva
  {
    public int Idreserva { get; set; }
    public int Idservicio { get; set; }
    public int Idhorario { get; set; }
    public int Idusuario { get; set; }
    public DateTime Fecha_reserva { get; set; }
    public decimal Precio { get; set; }
    public string Direccion { get; set; }
    public string Comentario { get; set; }
    public bool Estado { get; set; }

    [ForeignKey("Idservicio")]
    public Servicio Servicio { get; set; }
    [ForeignKey("Idhorario")]
    public Horario Horario { get; set; }
    [ForeignKey("Idusuario")]
    public Usuario Usuario { get; set; } 
  }
}
