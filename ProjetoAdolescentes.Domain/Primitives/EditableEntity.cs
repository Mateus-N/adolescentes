namespace ProjetoAdolescentes.Domain.Primitives;

public class EditableEntity : Entity
{
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    public DateTime? AtualizadoEm { get; set; }
    public DateTime? ExcluidoEm { get; set; }
}