using GerenciamentoDeTarefas.Application.Interfaces;
using GerenciamentoDeTarefas.Domain.Entities;
using GerenciamentoDeTarefas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeTarefas.Infrastructure.Repositories;

public class TarefaRepository : ITarefaRepository
{
    private readonly AppDbContext _context;

    public TarefaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Tarefa> CreateAsync(Tarefa tarefa)
    {
        _context.Tarefas.Add(tarefa);
        await _context.SaveChangesAsync();
        return tarefa;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);
        if (tarefa == null) return false;

        _context.Tarefas.Remove(tarefa);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Tarefa>> GetAllAsync()
    {
        return await _context.Tarefas.ToListAsync();
    }

    public async Task<Tarefa?> GetByIdAsync(int id)
    {
        return await _context.Tarefas.FindAsync(id);
    }

    public async Task<bool> UpdateAsync(Tarefa tarefa)
    {
        _context.Tarefas.Update(tarefa);
        await _context.SaveChangesAsync();
        return true;
    }
}