using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Context;
using ToDoList.Models;

namespace ToDoList.Controllers;

[Route("[controller]")]
[ApiController]
public class TarefaController : ControllerBase
{
    private readonly AppDbContext _context;

    public TarefaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Tarefa>> Get()
    {
        var tarefas = _context.Tarefas;
        return tarefas;
    }

    [HttpGet("/{id}")]
    public ActionResult<Tarefa> GetById(int id)
    {
        var tarefa = _context.Tarefas.FirstOrDefault(t => t.TarefaId == id);
        if (tarefa is null)
            return NotFound("Tarefa não encontrada");
        return tarefa;
    }

    [HttpPost("/{id}")]
    public ActionResult<Tarefa> Post(Tarefa tarefa)
    {
        _context.Tarefas.Add(tarefa);
        _context.SaveChanges();

        return Ok("tarefa criada!");
    }

    [HttpPut("/{id}")]
    public ActionResult<Tarefa> Put(int id, Tarefa tarefa)
    {
        if (id != tarefa.TarefaId)
            return BadRequest("Tarefa não existe");

        _context.Entry(tarefa).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(tarefa);
    }
}
