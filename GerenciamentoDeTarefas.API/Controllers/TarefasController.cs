using GerenciamentoDeTarefas.Application.Interfaces;
using GerenciamentoDeTarefas.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeTarefas.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefasController : ControllerBase
{
    private readonly ITarefaService _service;

    public TarefasController(ITarefaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var tarefa = await _service.GetByIdAsync(id);
        return tarefa == null ? NotFound() : Ok(tarefa);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Tarefa tarefa)
    {
        try
        {
            var result = await _service.CreateAsync(tarefa);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Tarefa tarefa)
    {
        if (id != tarefa.Id) return BadRequest("ID inválido.");

        try
        {
            var result = await _service.UpdateAsync(tarefa);
            return result ? NoContent() : NotFound();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        return result ? NoContent() : NotFound();
    }
}