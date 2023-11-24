using CrudApi.Models;
using Crud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewUsuario : ControllerBase
{
    public NewUsuario(ApplicationDbContext db) =>
        this.db = db;

    // GET: api/Usuario
    [HttpGet]
    public ActionResult<IEnumerable<Usuario>> Get()
    {
        if (db.Usuarios == null)
            return NotFound("Nenhuma ficha cadastrada.");

        return db.Usuarios;
    }

    // GET: api/Usuario/5
    [HttpGet("{id}")]
    public ActionResult<Usuario> GetId(int id)
    {
        var obj = db.Usuarios.FirstOrDefault(x => x.Id == id);

        if (obj == null)
            return NotFound("N�o foi encontrado nenhum usuario com o identificador informado.");

        return obj;
    }

    // POST: api/Usuario
    [HttpPost("Usuario")]
    public ActionResult<Usuario> Post(Usuario obj)
    {
        if (obj.Id == null || obj.Id == 0)
        {
            obj.Id = Convert.ToInt32(Guid.NewGuid().ToString("N").Substring(0, 8), 16);
        }

        db.Usuarios.Add(obj);
        db.SaveChanges();

        return CreatedAtAction(
            nameof(GetId),
            new { id = obj.Id },
            obj
        );
    }

    // PUT: api/Usuario/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, Usuario obj)
    {
        if (id != obj.Id)
            return BadRequest("O identificador informado difere do identificador do objeto");

        db.Usuarios.Update(obj);
        db.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Usuario/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (db.Usuarios == null)
            return NotFound("Nenhum usuario cadastrado.");

        var obj = db.Usuarios.FirstOrDefault(x => x.Id == id);

        if (obj == null)
            return NotFound("N�o foi encontrado nenhum usuario com o identificador informado.");

        db.Usuarios.Remove(obj);
        db.SaveChanges();

        return NoContent();
    }

    private readonly ApplicationDbContext db;
}
