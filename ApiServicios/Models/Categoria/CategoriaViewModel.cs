using System;
namespace ApiServicios.Models.Categoria
{
  public class CategoriaViewModel
  {
    public int Idcategoria { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public bool Estado { get; set; }
  }
}
