using CrudApi.Models;
using Crud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NovaFichaController : ControllerBase
{
    public NovaFichaController(ApplicationDbContext db) =>
        this.db = db;

    // GET: api/Ficha
    [HttpGet]
    public ActionResult<IEnumerable<Ficha>> Get()
    {
        if (db.Fichas == null)
            return NotFound("Nenhuma ficha cadastrada.");

        return db.Fichas;
    }

    // GET: api/Ficha/5
    [HttpGet("{id}")]
    public ActionResult<Ficha> GetId(string id)
    {
        var obj = db.Fichas.FirstOrDefault(x => x.Id == id);

        if (obj == null)
            return NotFound("N�o foi encontrado nenhuma ficha com o identificador informado.");

        return obj;
    }

    // POST: api/Ficha
    [HttpPost("Ficha")]
    public ActionResult<Ficha> Post(Ficha obj)
    {
        if (string.IsNullOrWhiteSpace(obj.Id))
            obj.Id = Guid.NewGuid().ToString();

        db.Fichas.Add(obj);
        db.SaveChanges();

        return CreatedAtAction(
            nameof(GetId),
            new { id = obj.Id },
            obj
        );
    }

    // PUT: api/Ficha/5
    [HttpPut("{id}")]
    public IActionResult Put(string id, Ficha obj)
    {
        if (id != obj.Id)
            return BadRequest("O identificador informado difere do identificador do objeto");

        db.Fichas.Update(obj);
        db.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Ficha/5
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        if (db.Fichas == null)
            return NotFound("Nenhuma ficha cadastrada.");

        var obj = db.Fichas.FirstOrDefault(x => x.Id == id);

        if (obj == null)
            return NotFound("N�o foi encontrado nenhuma ficha com o identificador informado.");

        db.Fichas.Remove(obj);
        db.SaveChanges();

        return NoContent();
    }

    private readonly ApplicationDbContext db;
}
