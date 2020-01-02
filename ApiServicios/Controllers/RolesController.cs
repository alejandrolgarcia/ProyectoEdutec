using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiServicios.Models.Rol;
using Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiServicios.Controllers
{
  [Route("api/[controller]")]
  public class RolesController : Controller
  {
    private readonly DbContextServicios _context;

    public RolesController(DbContextServicios context)
    {
      _context = context;
    }

    // GET: api/Roles/GetAll
    [HttpGet("[action]")]
    public async Task<IEnumerable<RolViewModel>> GetAll()
    {
      var rol = await _context.Roles.ToListAsync();

      return rol.Select(r => new RolViewModel
      {
        Idrol = r.Idrol,
        Nombre = r.Nombre,
        Descripcion = r.Descripcion,
        Estado = r.Estado
      });
    }

    // GET: api/Roles/Select
    [HttpGet("[action]")]
    public async Task<IEnumerable<SelectViewModel>> Select()
    {
      var rol = await _context.Roles.Where(r => r.Estado == true).ToListAsync();

      return rol.Select(r => new SelectViewModel
      {
        Idrol = r.Idrol,
        Nombre = r.Nombre
      });
    }
  }
}
