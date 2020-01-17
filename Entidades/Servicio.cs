using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
  public class Servicio
  {
    public int Idservicio { get; set; }
    public int Idcategoria { get; set; }
    public int Idusuario { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
    public int Calificacion { get; set; }
    public DateTime Fecha_servicio { get; set; }
    public bool Estado { get; set; }

    [ForeignKey("Idcategoria")]
    public Categoria Categorias { get; set; }
    [ForeignKey("Idusuario")]
    public Usuario Usuarios { get; set; }

    public ICollection<Horario> Horarios { get; set; }
    public ICollection<Reserva> Reservas { get; set; }
    
  }
}
