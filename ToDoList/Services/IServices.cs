using ToDoList.Models;

namespace ToDoList.Services;

public interface IServices
{
    public IEnumerable<Tarefa> GetAll(int userId);
    public Tarefa Get(int id);
    public Tarefa Post(Tarefa tarefa);
    public Tarefa Put(Tarefa tarefa, int id);
    public Tarefa Delete(int id);
}
