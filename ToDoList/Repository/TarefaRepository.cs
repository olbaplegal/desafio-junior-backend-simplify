using Microsoft.EntityFrameworkCore;
using ToDoList.Context;
using ToDoList.Models;

namespace ToDoList.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Tarefa> GetTarefas()
        {
            var tarefas = _context.Tarefas.ToList();
            return tarefas;
        }
        public Tarefa GetTarefa(int id)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(t => t.TarefaId == id);
            return tarefa;
        }
        public Tarefa Add(Tarefa tarefa)
        {
            if (tarefa == null)
                throw new ArgumentException(nameof(tarefa));

            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            return tarefa;
        }
        public Tarefa Update(Tarefa tarefa)
        {
            if (tarefa == null)
                throw new ArgumentException(nameof(tarefa));

            _context.Entry(tarefa).State = EntityState.Modified;
            _context.SaveChanges();
            return tarefa;
        }
        public Tarefa Delete(int id)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(t => t.TarefaId == id);

            if (tarefa == null)
                throw new ArgumentException(nameof(tarefa));

            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();
            return tarefa;
        }
    }
}
