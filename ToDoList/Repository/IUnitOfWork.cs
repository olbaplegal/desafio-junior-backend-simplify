namespace ToDoList.Repository;

public interface IUnitOfWork
{
    ITarefaRepository TarefaRepository { get; }

    void Commit();
}
