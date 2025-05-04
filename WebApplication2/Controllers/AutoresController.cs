using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebApplication2.Datos;
using WebApplication2.Entidades;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {
        private readonly AplicationDbContext context;

        public AutoresController(AplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Autor>> Get()
        {
            return await context.Autores.ToArrayAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Autor>> Get(int id)
        {
            var autor = await context.Autores.Include(x=> x.Libros).FirstOrDefaultAsync(x => x.Id == id);
            if (autor is null)
                return NotFound();

            return autor;            
        } 

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Autor autor, int id)
        {
            if(id != autor.Id)
                return BadRequest("Error de ids");
            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var borrados = await context.Autores.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (borrados == 0)
                return NotFound();
            return Ok();
        }
    }
}
