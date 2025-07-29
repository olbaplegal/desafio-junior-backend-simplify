using ToDoList.Context;

namespace ToDoList.Repository;

public class UnitOfWork : IUnitOfWork
{
    private ITarefaRepository _tarefaRepo;
    public AppDbContext _context;
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public ITarefaRepository TarefaRepository
    {
        get
        {
            return _tarefaRepo = _tarefaRepo ?? new TarefaRepository(_context);
        }
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
