using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace ToDoList.Models;

public class Tarefa
{
    [Key]
    public int TarefaId { get; set; }
    [Required]
    public string? Nome { get; set; }
    [Required]
    public string? Descricao { get; set; }
    public bool Realizado { get; set; }
    public Prioridade Prioridade { get; set; }
}
