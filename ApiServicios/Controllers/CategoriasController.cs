using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiServicios.Models.Categoria;
using Datos;
using Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiServicios.Controllers
{
  [Authorize(Roles= "Administrador, Profesional")]
  [Route("api/[controller]")]
  public class CategoriasController : Controller
  {
    private readonly DbContextServicios _context;

    public CategoriasController(DbContextServicios context)
    {
      _context = context;
    }

    // Obtener todas las categorias

    // GET: api/Categorias/GetAll
    [HttpGet("[action]")]
    public async Task<IEnumerable<CategoriaViewModel>> GetAll()
    {
      var categoria = await _context.Categorias.ToListAsync();

      return categoria.Select(c => new CategoriaViewModel
      {
        Idcategoria = c.Idcategoria,
        Nombre = c.Nombre,
        Descripcion = c.Descripcion,
        Estado = c.Estado
      });
    }

    // Obtener una categoria por Id

    // GET api/Categorias/GetItem/5
    [HttpGet("[action]/{id}")]
    public async Task<ActionResult> GetItem([FromRoute]int id)
    {
      var categoria = await _context.Categorias.FindAsync(id);

      if (categoria == null)
        return NotFound();

      return Ok(new CategoriaViewModel
      {
        Idcategoria = categoria.Idcategoria,
        Nombre = categoria.Nombre,
        Descripcion = categoria.Descripcion,
        Estado = categoria.Estado
      });
    }

    // Crear una nueva categoria

    // POST api/Categorias/Create
    [HttpPost("[action]")]
    public async Task<ActionResult> Create([FromBody]CreateViewModel model)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      Categoria categoria = new Categoria
      {
        Nombre = model.Nombre,
        Descripcion = model.Descripcion,
        Estado = true
      };

      _context.Categorias.Add(categoria);

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

    // Actualizar una categoria

    // PUT api/Categorias/Update
    [HttpPut("[action]")]
    public async Task<IActionResult> Update([FromBody] CategoriaViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (model.Idcategoria <= 0)
      {
        return BadRequest();
      }

      var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.Idcategoria == model.Idcategoria);

      if (categoria == null)
      {
        return NotFound();
      }

      categoria.Nombre = model.Nombre;
      categoria.Descripcion = model.Descripcion;
      categoria.Estado = model.Estado;

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

    // Anular una categoria

    // DELETE api/Categorias/Delete/5
    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      if (id <= 0)
      {
        return BadRequest();
      }

      var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.Idcategoria == id);

      if (categoria == null)
      {
        return NotFound();
      }

      categoria.Estado = false;

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
  }
}
