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
    private readonly ITarefaRepository _repository;

    public TarefaController(ITarefaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Tarefa>> Get()
    {
        var tarefas = _repository.GetTarefas();
        return Ok(tarefas);
    }

    [HttpGet("/{id}")]
    public ActionResult<Tarefa> GetById(int id)
    {
        var tarefa = _repository.GetTarefa(id);

        if (tarefa is null)
            return NotFound("Tarefa não encontrada");
        return tarefa;
    }

    [HttpPost("/{id}")]
    public ActionResult<Tarefa> Post(Tarefa tarefa)
    {
        _repository.Add(tarefa);

        return Ok("tarefa criada!");
    }

    [HttpPut("/{id}")]
    public ActionResult<Tarefa> Put(int id, Tarefa tarefa)
    {
        if (id != tarefa.TarefaId)
            return BadRequest("Tarefa não existe");

        _repository.Update(tarefa);

        return Ok(tarefa);
    
    }
    [HttpDelete("/{id}")]
    public ActionResult<Tarefa> Delete(int id)
    {
        var tarefa = _repository.GetTarefa(id);

        if (tarefa is null)
            return NotFound("Tarefa não encontrada");

        _repository.Delete(id);

        return Ok(tarefa);
    }
}
