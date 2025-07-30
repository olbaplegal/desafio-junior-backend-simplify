using ToDoList.Models;

namespace ToDoList.Repository;

public interface IServices
{
    public IEnumerable<Tarefa> GetAll();
    public Tarefa Get(int id);
    public Tarefa Post(Tarefa tarefa);
    public Tarefa Put(Tarefa tarefa, int id);
    public Tarefa Delete(int id);
}
