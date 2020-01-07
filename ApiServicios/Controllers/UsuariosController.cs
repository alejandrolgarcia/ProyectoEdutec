using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiServicios.Models.Usuario;
using Datos;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiServicios.Controllers
{
  [Route("api/[controller]")]
  public class UsuariosController : Controller
  {
    private readonly DbContextServicios _context;
    private readonly IConfiguration _config;

    public UsuariosController(DbContextServicios context, IConfiguration config)
    {
      _context = context;
      _config = config;
    }

    // GET: api/Usuarios/GetAll
    [HttpGet("[action]")]
    public async Task<IEnumerable<UsuarioViewModel>> GetAll()
    {
      var usuario = await _context.Usuarios.Include(u => u.Rol).ToListAsync();

      return usuario.Select(u => new UsuarioViewModel
      {
        Idusuario = u.Idusuario,
        Idrol = u.Idrol,
        Rol = u.Rol.Nombre,
        Nombre = u.Nombre,
        Apellido = u.Apellido,
        Email = u.Email,
        Password_hash = u.Password_hash,
        Estado = u.Estado
      });
    }

    // POST api/Usuarios/Create
    [HttpPost("[action]")]
    public async Task<ActionResult> Create([FromBody]CreateViewModel model)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      // Validar si el Email ya existe
      var email = model.Email.ToLower();

      if (await _context.Usuarios.AnyAsync(u => u.Email == email))
      {
        return BadRequest("El email ya existe");
      }

      CrearPasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);

      Usuario usuario = new Usuario
      {
        Idrol = model.Idrol,
        Nombre = model.Nombre,
        Apellido = model.Apellido,
        Email = model.Email.ToLower(),
        Password_hash = passwordHash,
        Password_salt = passwordSalt,
        Estado = true
      };

      _context.Usuarios.Add(usuario);

      try
      {
        await _context.SaveChangesAsync();
        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }

    // Funcion para transformar el password
    private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
      using (var hmac = new System.Security.Cryptography.HMACSHA512())
      {
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
      }
    }

    
    // PUT api/Usuarios/Update
    [HttpPut("[action]")]
    public async Task<IActionResult> Update([FromBody] UpdateViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (model.Idusuario <= 0)
      {
        return BadRequest();
      }

      var usuario = await _context.Usuarios.FirstOrDefaultAsync(c => c.Idusuario == model.Idusuario);

      if (usuario == null)
      {
        return NotFound();
      }

      usuario.Idrol = model.Idrol;
      usuario.Nombre = model.Nombre;
      usuario.Apellido = model.Apellido;
      usuario.Email = model.Email;
      usuario.Estado = model.Estado;

      // Solo si cambia la password.
      if (model.Act_password == true)
      {
        CrearPasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);
        usuario.Password_hash = passwordHash;
        usuario.Password_salt = passwordSalt;
      }

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException ex)
      {
        return BadRequest(ex);
      }

      return Ok();

    }

    // DELETE api/Usuarios/Delete/5
    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      if (id <= 0)
      {
        return BadRequest();
      }

      var usuario = await _context.Usuarios.FirstOrDefaultAsync(c => c.Idusuario == id);

      if (usuario == null)
      {
        return NotFound();
      }

      usuario.Estado = false;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException ex)
      {
        return BadRequest(ex);
      }

      return Ok();

    }

    // POST api/Usuarios/Login
    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
      
      string email = model.Email;

      var usuario = await _context.Usuarios
        .Where( u => u.Estado == true)
        .Include(u => u.Rol)
        .FirstOrDefaultAsync( u => u.Email == email);

      if ( usuario == null)
      {
        return NotFound();
      }

      if (!VerificarPasswordHash(model.Password, usuario.Password_hash, usuario.Password_salt))
      {
        return NotFound();
      }

      // 
      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.NameIdentifier, usuario.Idusuario.ToString()),
        new Claim(ClaimTypes.Email, email),
        new Claim(ClaimTypes.Role, usuario.Rol.Nombre),

        new Claim("Idusuario", usuario.Idusuario.ToString()),
        new Claim("Rol", usuario.Rol.Nombre),
        new Claim("Nombre", usuario.Nombre)
      };

      return Ok(new { token = GenerarToken(claims)});
    }

    // Metodo recibe el password que escribe el usuario y comparar si es el mismo que se encuentra almacenado.

    private bool VerificarPasswordHash( string password, byte[] passwordHashAlmacenado, byte[] passwordSalt)
    {
      using ( var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
      {
        var passwordHashNuevo = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        return new ReadOnlySpan<byte>(passwordHashAlmacenado).SequenceEqual(new ReadOnlySpan<byte>(passwordHashNuevo));
      }
    }


    // Generar token con JWT
    private string GenerarToken(List<Claim> claims)
    {
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
      var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
        _config["Jwt:Issuer"],
        _config["Jwt:Issuer"],
        expires: DateTime.Now.AddMinutes(30),
        signingCredentials: credenciales,
        claims: claims
        );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }

  }
}
