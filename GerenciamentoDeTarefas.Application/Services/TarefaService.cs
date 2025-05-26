using GerenciamentoDeTarefas.Application.Interfaces;
using GerenciamentoDeTarefas.Domain.Entities;

namespace GerenciamentoDeTarefas.Application.Services;

public class TarefaService : ITarefaService
{
    private readonly ITarefaRepository _repository;

    public TarefaService(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Tarefa> CreateAsync(Tarefa tarefa)
    {
        if (string.IsNullOrWhiteSpace(tarefa.Titulo) || tarefa.Titulo.Length > 100)
            throw new ArgumentException("Título é obrigatório e deve ter até 100 caracteres.");

        tarefa.DataCriacao = DateTime.UtcNow;

        if (tarefa.DataConclusao.HasValue && tarefa.DataConclusao < tarefa.DataCriacao)
            throw new ArgumentException("A data de conclusão não pode ser anterior à data de criação.");

        return await _repository.CreateAsync(tarefa);
    }

    public async Task<bool> DeleteAsync(int id) => await _repository.DeleteAsync(id);

    public async Task<IEnumerable<Tarefa>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<Tarefa?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task<bool> UpdateAsync(Tarefa tarefa)
    {
        if (string.IsNullOrWhiteSpace(tarefa.Titulo) || tarefa.Titulo.Length > 100)
            throw new ArgumentException("Título é obrigatório e deve ter até 100 caracteres.");

        if (tarefa.DataConclusao.HasValue && tarefa.DataConclusao < tarefa.DataCriacao)
            throw new ArgumentException("A data de conclusão não pode ser anterior à data de criação.");

        return await _repository.UpdateAsync(tarefa);
    }
}