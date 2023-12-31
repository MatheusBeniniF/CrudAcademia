namespace Crud.Models;

public class Ficha
{
    public int? Id { get; set; }
    public string Titulo { get; set; } = "";
    public string User { get; set; } = "";
    public bool? Sugestao { get; set; }
    public bool? EmAndamento { get; set; }
    public IList<ExercicioRecord> Exercicios { get; set; } = new List<ExercicioRecord>();
}