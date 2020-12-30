using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Context;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TareasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listTareas = await _context.Tareas.ToListAsync();
                return Ok(listTareas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tarea tarea)
        {
            try
            {
                _context.Tareas.Add(tarea);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La tarea fue registrada con éxito." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Tarea tarea)
        {
            try
            {
                if (id != tarea.Id)
                {
                    return NotFound();
                }
                tarea.Estado = !tarea.Estado;
                _context.Entry(tarea).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new { message = "La tarea fue actualizada con éxito." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var tarea = await _context.Tareas.FindAsync(id);
                if (tarea == null)
                {
                    return NotFound();
                }
                _context.Tareas.Remove(tarea);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Tarea eliminada con éxito." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
