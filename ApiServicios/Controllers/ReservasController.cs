using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiServicios.Models.Reserva;
using Datos;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiServicios.Controllers
{
  [Route("api/[controller]")]
  public class ReservasController : Controller
  {
    private readonly DbContextServicios _context;

    public ReservasController(DbContextServicios context)
    {
      _context = context;
    }

    // GET: api/Reservas/GetAll
    [HttpGet("[action]")]
    public async Task<IEnumerable<ReservaViewModel>> GetAll()
    {
      var reservas = await _context.Reservas
        .Include( r => r.Servicio)
        .Include( r => r.Horario)
        .Include( r => r.Usuario)
        .ToListAsync();

      return reservas.Select(r => new ReservaViewModel
      {
        Idreserva = r.Idreserva,
        Idservicio = r.Idservicio,
        Nombreservicio = r.Servicio.Nombre,
        Idhorario = r.Idhorario,
        Hora_inicio = r.Horario.Hora_inicio,
        Hora_fin = r.Horario.Hora_final,
        Idusuario = r.Idusuario,
        Fecha_reserva = r.Fecha_reserva,
        Precio = r.Precio,
        Direccion = r.Direccion,
        Estado = true
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
