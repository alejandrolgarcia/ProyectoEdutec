using System;
namespace ApiServicios.Models.Usuario
{
  public class UsuarioViewModel
  {
    public int Idusuario { get; set; }
    public int Idrol { get; set; }
    public string Rol { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public byte[] Password_hash { get; set; }
    public bool Estado { get; set; }
  }
}
