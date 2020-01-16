using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiServicios.Models.Servicio;
using Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiServicios.Controllers
{
  [Route("api/[controller]")]
  public class ServiciosController : Controller
  {
    private readonly DbContextServicios _context;

    public ServiciosController(DbContextServicios context)
    {
      _context = context;
    }

    // GET: api/Servicios/GetAll
    [HttpGet("[action]")]
    public async Task<IEnumerable<ServicioViewModel>> GetAll()
    {
      var servicios = await _context.Servicios
        .Include(s => s.Categorias)
        .Include(s => s.Usuarios)
        .OrderBy(s => s.Fecha_servicio)
        .ToListAsync();

      return servicios.Select( s => new ServicioViewModel
      {
        Idservicio = s.Idservicio,
        Idcategoria = s.Idcategoria,
        Categoria = s.Categorias.Nombre,
        Idusuario = s.Idusuario,
        Usuario = s.Usuarios.Nombre,
        Nombre = s.Nombre,
        Descripcion = s.Descripcion,
        Precio = s.Precio,
        Calificacion = s.Calificacion,
        Fecha_servicio = s.Fecha_servicio,
        Estado = s.Estado
      });

    }

    // GET api/values/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody]string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
