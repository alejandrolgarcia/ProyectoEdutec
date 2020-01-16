using System;
namespace ApiServicios.Models.Servicio
{
  public class ServicioViewModel
  {
    public int Idservicio { get; set; }
    public int Idcategoria { get; set; }
    public string Categoria { get; set; }
    public int Idusuario { get; set; }
    public string Usuario { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
    public int Calificacion { get; set; }
    public DateTime Fecha_servicio { get; set; }
    public bool Estado { get; set; }
  }
}
