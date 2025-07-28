using Microsoft.AspNetCore.Mvc;
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
        var tarefas = _context.Tarefas.ToList();
        if (tarefas is null)
            return NotFound("Tarefa não encontrada");
        return tarefas;
    }
}
