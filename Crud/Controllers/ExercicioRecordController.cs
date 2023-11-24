using CrudApi.Models;
using Crud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExercicioRecordController : ControllerBase
{
    public ExercicioRecordController(ApplicationDbContext db) => 
        this.db = db;
        
    // GET: api/ExercicioRecord/5
    [HttpGet("{id}")]
    public ActionResult<ExercicioRecord> GetId(int id)
    {
        var obj = db.ExercicioRecords.FirstOrDefault(x => x.Id == id);

        if (obj == null)
            return NotFound("N�o foi encontrado nenhum exercicio com o identificador informado.");

        return obj;
    }

    // GET: api/ExercicioRecord/
    [HttpGet("ExercicioRecord")]
    public ActionResult<IEnumerable<ExercicioRecord>> Get()
    {

        if (db.ExercicioRecords == null)
            return NotFound("N�o foi encontrado nenhum exercicio");

        return db.ExercicioRecords;
    }

    // DELETE: api/ExercicioRecord/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (db.ExercicioRecords == null)
            return NotFound("Nenhum record cadastrado.");

        var obj = db.ExercicioRecords.FirstOrDefault(x => x.Id == id);

        if (obj == null)
            return NotFound("N�o foi encontrado nenhum record com o identificador informado.");

        db.ExercicioRecords.Remove(obj);
        db.SaveChanges();

        return NoContent();
    }

    private readonly ApplicationDbContext db;
}
