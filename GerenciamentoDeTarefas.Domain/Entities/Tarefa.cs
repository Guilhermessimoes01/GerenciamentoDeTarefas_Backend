using GerenciamentoDeTarefas.Domain.Enums;

namespace GerenciamentoDeTarefas.Domain.Entities;

using GerenciamentoDeTarefas.Domain;
public class Tarefa
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataConclusao { get; set; }
    public Enums.TaskStatus Status { get; set; }
}