using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoEnEquipoCrud.Context;
using ProyectoEnEquipoCrud.Models;

namespace ProyectoEnEquipoCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TituloController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TituloController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("LISTA-LEER")]
        public IActionResult lista()
        {
            var Titulo = this._context.titulos.ToList();
            return Ok(Titulo);
        }

        [HttpPost]
        [Route("CREAR-Titulo")]
        public IActionResult CrearTitulo([FromBody] Titulo nuevoTitulo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.titulos.Add(nuevoTitulo);
                    _context.SaveChanges();
                }
                return Ok(new { mensaje = "Creacion exitosa" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mesaje = error.Message });
            }
        }

        [HttpPut("EDITAR/{Id_Titulo}")]
        public IActionResult EditarTitulo(int Id_Titulo, [FromBody] Titulo TituloActualizada)
        {
            try
            {
                var TituloExistente = _context.titulos.Find(Id_Titulo);

                if (TituloExistente == null)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    TituloExistente.titulo = TituloActualizada.titulo;
                    TituloExistente.descripcion = TituloActualizada.descripcion;

                    _context.SaveChanges();
                }
                return Ok(new { mensaje = "Edición exitosa" });

            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }

        [HttpDelete("ELIMINAR/{Id_Titulo}")]
        public IActionResult EliminarTitulo(int Id_Titulo)
        {
            try
            {

                var titulo = _context.titulos.Find(Id_Titulo);

                if (titulo == null)
                {
                    return NotFound();
                }

                _context.titulos.Remove(titulo);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mesaje = "Eliminado" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mesaje = error.Message });
            }
        }
    }
}
