using ToDoList.Models;

namespace ToDoList.Repository;

public interface ITarefaRepository
{
    IEnumerable<Tarefa> GetTarefas();
    Tarefa GetTarefa(int id);
    Tarefa Add(Tarefa tarefa);
    Tarefa Update(Tarefa tarefa);
    Tarefa Delete(int id);
}
