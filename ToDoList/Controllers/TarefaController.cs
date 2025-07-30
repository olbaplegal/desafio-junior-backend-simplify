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
    private readonly IServices _services;

    public TarefaController(IServices services)
    {
        _services = services;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Tarefa>> Get()
    {
        var tarefa = _services.GetAll();
        return Ok(tarefa);
    }

    [HttpGet("/{id}")]
    public ActionResult<Tarefa> Get(int id)
    {
        var tarefa = _services.Get(id);
        return Ok(tarefa);
    }

    [HttpPost]
    public ActionResult<Tarefa> Post(Tarefa tarefa)
    {
        var novaTarefa = _services.Post(tarefa);
        return Ok(novaTarefa);
    }

    [HttpPut("/{id}")]
    public ActionResult<Tarefa> Put(int id, Tarefa tarefa)
    {
        var tarefaAtualizado = _services.Put(tarefa, id);
        return Ok(tarefaAtualizado);
    }

    [HttpDelete("/{id}")]
    public ActionResult<Tarefa> Delete(int id)
    {
        var tarefa = _services.Delete(id);
        return Ok(tarefa);  
    }
}
