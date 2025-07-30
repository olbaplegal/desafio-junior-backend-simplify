using ToDoList.Models;

namespace ToDoList.Repository;

public class Services : IServices
{
    private readonly IUnitOfWork _uof;

    public Services(IUnitOfWork uof)
    {
        _uof = uof;
    }

    public IEnumerable<Tarefa> GetAll()
    {
        var tarefas = _uof.TarefaRepository.GetTarefas();
        return tarefas;
    }

    public Tarefa Get(int id)
    {
        var tarefa = _uof.TarefaRepository.GetTarefa(id);

        if (tarefa is null)
            throw new Exception("Tarefa não encontrada");
        return tarefa;
    }


    public Tarefa Post(Tarefa tarefa)
    {
        var novaTarefa = _uof.TarefaRepository.Add(tarefa);
        _uof.Commit();

        return tarefa;
    }

    public Tarefa Put(Tarefa tarefa, int id)
    {
        if (id != tarefa.TarefaId)
            throw new Exception("Tarefa não existe");

        var tarefaAtualizada = _uof.TarefaRepository.Update(tarefa);
        _uof.Commit();

        return tarefaAtualizada;
    }

    public Tarefa Delete(int id)
    {
        var tarefa = _uof.TarefaRepository.GetTarefa(id);

        if (tarefa is null)
            throw new Exception("Tarefa não encontrada");

        _uof.TarefaRepository.Delete(id);
        _uof.Commit();

        return tarefa;
    }
}
