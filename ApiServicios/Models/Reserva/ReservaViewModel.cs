using System;
namespace ApiServicios.Models.Reserva
{
  public class ReservaViewModel
  {
    public int Idreserva { get; set; }
    public int Idservicio { get; set; }
    public string Nombreservicio { get; set; }
    public int Idhorario { get; set; }
    public DateTime Hora_inicio { get; set; }
    public DateTime Hora_fin { get; set; }
    public int Idusuario { get; set; }
    public DateTime Fecha_reserva { get; set; }
    public decimal Precio { get; set; }
    public string Direccion { get; set; }
    public bool Estado { get; set; }
  }
}
