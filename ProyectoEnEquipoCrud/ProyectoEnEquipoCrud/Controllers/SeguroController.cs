using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoEnEquipoCrud.Context;
using ProyectoEnEquipoCrud.Models;

namespace ProyectoEnEquipoCrud.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SalarioController : ControllerBase
    {

        private readonly ILogger<SalarioController> _logger;
        private readonly ApplicationDbContext _ApplicationDbContext;
        public SalarioController(
            ILogger<SalarioController> logger,
            ApplicationDbContext ApplicationDbContext)
        {
            _logger = logger;
            _ApplicationDbContext = ApplicationDbContext;
        }
        //[HttpPost(Name = "CrearSalario")]
        [HttpPost]
        [Route("Salario")]
        public async Task<IActionResult> PostSalario([FromBody] Salario Salario)
        {
            _ApplicationDbContext.Salario.Add(Salario);
            _ApplicationDbContext.SaveChanges();
            return Ok(Salario);
        }


        // [HttpGet(Name = "GetSalario")]

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetSalario()
        {
            List<Salario> listSalario = _ApplicationDbContext.Salario.ToList();

            return StatusCode(StatusCodes.Status200OK, listSalario);
        }

        //[HttpPut(Name = "PutSalario")]
        [HttpPut]
        [Route("EditarSalario/")]
        public async Task<IActionResult> EditSalario([FromBody] Salario Salario)
        {
            _ApplicationDbContext.Salario.Update(Salario);
            _ApplicationDbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "editado");


        }

        [HttpDelete]
        [Route("EliminarSalario/")]
        //[HttpDelete(Name = "DeleteSalario")]
        public async Task<IActionResult> DeleteSalario(int? id)
        {
            Salario Salario = _ApplicationDbContext.Salario.Find(id);
            _ApplicationDbContext.Salario.Remove(Salario);
            _ApplicationDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "eliminado");
        }
    }

}