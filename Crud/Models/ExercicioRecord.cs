namespace Crud.Models;
public class ExercicioRecord
{
    public int FichaId { get; set; }
    public int? Id { get; set; }
    public string Exercicio { get; set; } = null!;
    public string? Carga { get; set; }
    public int Intervalo { get; set; }
    public int QtdSeries { get; set; }
    public int Repeticoes { get; set; }
    public string? Anotacoes { get; set; } = "";
}
