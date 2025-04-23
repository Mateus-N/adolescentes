namespace ProjetoAdolescentes.Domain.Primitives;

public class CriticalEntity : EditableEntity
{
    public Guid Guid { get; set; } = Guid.NewGuid();
}