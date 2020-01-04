using System;
using System.ComponentModel.DataAnnotations;

namespace ApiServicios.Models.Usuario
{
  public class UpdateViewModel
  {
    [Required]
    public int Idusuario { get; set; }
    [Required]
    public int Idrol { get; set; }
    [Required]
    [StringLength(64, MinimumLength = 3, ErrorMessage = "El nombre no debe tener mas de 64 caracteres y menos de 3 caracteres")]
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public bool Act_password { get; set; }
    public bool Estado { get; set; }
  }
}
