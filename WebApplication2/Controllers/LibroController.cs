using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Datos;
using WebApplication2.Entidades;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibroController : ControllerBase
    {
        private readonly AplicationDbContext context;

        public LibroController(AplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Libro>> Get()
        {
            return await context.Libros.ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Libro>> Get(int id)
        {
            var libro = await context.Libros.Include(x=>x.Autor).FirstOrDefaultAsync(x => x.Id == id);
            if(libro is null)
                return NotFound();

            return libro;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Libro libro)
        {
            context.Add(libro);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Libro libro)
        {
            if (id != libro.Id)
                return BadRequest("Id no encontrado");
            context.Update(libro);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var borrados = await context.Libros.Where(x=> x.Id == id).ExecuteDeleteAsync();
            if (borrados == 0)
                return NotFound();
            return Ok();
        }

    }
}
