using CrudApi.Models;
using Crud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RequerirNovaFichaController : ControllerBase
{
    public RequerirNovaFichaController(ApplicationDbContext db) =>
        this.db = db;

    // GET: api/RequerirNovaFicha
    [HttpGet]
    public ActionResult<IEnumerable<RequerirNovaFicha>> Get()
    {
        if (db.RequerirNovaFichas == null)
            return NotFound("Nenhuma ficha cadastrada.");

        return db.RequerirNovaFichas;
    }

    // GET: api/RequerirNovaFicha/5
    [HttpGet("{id}")]
    public ActionResult<RequerirNovaFicha> GetId(int id)
    {
        var obj = db.RequerirNovaFichas.FirstOrDefault(x => x.Id == id);

        if (obj == null)
            return NotFound("N�o foi encontrado nenhuma ficha com o identificador informado.");

        return obj;
    }

    // POST: api/RequerirNovaFicha
    [HttpPost("RequerirNovaFicha")]
    public ActionResult<RequerirNovaFicha> Post(RequerirNovaFicha obj)
    {
        if (obj.Id == null || obj.Id == 0)
        {
            obj.Id = Convert.ToInt32(Guid.NewGuid().ToString("N").Substring(0, 8), 16);
        }

        db.RequerirNovaFichas.Add(obj);
        db.SaveChanges();

        return CreatedAtAction(
            nameof(GetId),
            new { id = obj.Id },
            obj
        );
    }

    // DELETE: api/RequerirNovaFicha/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (db.RequerirNovaFichas == null)
            return NotFound("Nenhuma ficha cadastrada.");

        var obj = db.RequerirNovaFichas.FirstOrDefault(x => x.Id == id);

        if (obj == null)
            return NotFound("N�o foi encontrado nenhuma ficha com o identificador informado.");

        db.RequerirNovaFichas.Remove(obj);
        db.SaveChanges();

        return NoContent();
    }

    private readonly ApplicationDbContext db;
}
