using GerenciamentoDeTarefas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeTarefas.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Tarefa> Tarefas => Set<Tarefa>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarefa>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Titulo).IsRequired().HasMaxLength(100);
            entity.Property(t => t.Descricao);
            entity.Property(t => t.DataCriacao);
            entity.Property(t => t.DataConclusao);
            entity.Property(t => t.Status).HasConversion<int>();
        });
    }
}