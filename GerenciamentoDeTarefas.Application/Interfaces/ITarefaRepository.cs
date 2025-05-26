using GerenciamentoDeTarefas.Domain.Entities;

namespace GerenciamentoDeTarefas.Application.Interfaces;

public interface ITarefaRepository
{
    Task<IEnumerable<Tarefa>> GetAllAsync();
    Task<Tarefa?> GetByIdAsync(int id);
    Task<Tarefa> CreateAsync(Tarefa tarefa);
    Task<bool> UpdateAsync(Tarefa tarefa);
    Task<bool> DeleteAsync(int id);
}