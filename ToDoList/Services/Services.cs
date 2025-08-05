using ToDoList.Models;
using ToDoList.Repository;

namespace ToDoList.Services;

public class Services : IServices
{
    private readonly IUnitOfWork _uof;

    public Services(IUnitOfWork uof)
    {
        _uof = uof;
    }

    public IEnumerable<Tarefa> GetAll(int userId)
    {
        var tarefas = _uof.TarefaRepository.GetTarefas(userId);
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
        var existeTarefaComMesmoNome = _uof.TarefaRepository
                                       .GetTarefas(tarefa.UserId)
                                       .Any(t => t.Nome == tarefa.Nome);

        if (existeTarefaComMesmoNome)
        {
            throw new Exception("Nome da tarefa já existe!");
        }

        var novaTarefa = _uof.TarefaRepository.Add(tarefa);
        _uof.Commit();

        return novaTarefa;
    }


    public Tarefa Put(Tarefa tarefa, int id)
    {
        if (id != tarefa.TarefaId)
            throw new Exception("Tarefa não existe");

        var existeTarefaComMesmoNome = _uof.TarefaRepository
                                       .GetTarefas(tarefa.UserId)
                                       .Any(t => t.Nome == tarefa.Nome);

        if (existeTarefaComMesmoNome)
        {
            throw new Exception("Nome da tarefa já existe!");
        }

        var tarefaAtualizada = _uof.TarefaRepository.Update(tarefa);
        _uof.Commit();

        return tarefaAtualizada;
    }

    public Tarefa Delete(int id)
    {
        var tarefa = _uof.TarefaRepository.GetTarefa(id);

        if (tarefa is null)
            throw new Exception("Tarefa não encontrada");

        _uof.TarefaRepository.GetTarefa(id).IsDeleted = true;

        //_uof.TarefaRepository.Delete(id);
        _uof.Commit();

        return tarefa;
    }
}
