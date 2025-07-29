using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Context;
using ToDoList.Models;
using ToDoList.Repository;

namespace ToDoList.Controllers;

[Route("[controller]")]
[ApiController]
public class TarefaController : ControllerBase
{
    private readonly IUnitOfWork _uof;

    public TarefaController(IUnitOfWork uof)
    {
        _uof = uof;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Tarefa>> Get()
    {
        var tarefas = _uof.TarefaRepository.GetTarefas();
        return Ok(tarefas);
    }

    [HttpGet("/{id}")]
    public ActionResult<Tarefa> Get(int id)
    {
        var tarefa = _uof.TarefaRepository.GetTarefa(id);

        if (tarefa is null)
            return NotFound("Tarefa não encontrada");
        return tarefa;
    }

    [HttpPost("/{id}")]
    public ActionResult<Tarefa> Post(Tarefa tarefa)
    {
        var novaTarefa = _uof.TarefaRepository.Add(tarefa);
        _uof.Commit();

        return Ok(tarefa);
    }

    [HttpPut("/{id}")]
    public ActionResult<Tarefa> Put(int id, Tarefa tarefa)
    {
        if (id != tarefa.TarefaId)
            return BadRequest("Tarefa não existe");

        var tarefaAtualizada = _uof.TarefaRepository.Update(tarefa);
        _uof.Commit();

        return Ok(tarefaAtualizada);
    
    }

    [HttpDelete("/{id}")]
    public ActionResult<Tarefa> Delete(int id)
    {
        var tarefa = _uof.TarefaRepository.GetTarefa(id);

        if (tarefa is null)
            return NotFound("Tarefa não encontrada");

        _uof.TarefaRepository.Delete(id);
        _uof.Commit();

        return Ok(tarefa);
    }
}
