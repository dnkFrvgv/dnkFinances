using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DnkFinances.Data;
using DnkFinances.Repositories.IRepository;

namespace DnkFinances.Repositories
{
  public class Repository<T> : IRepository<T> where T : class
  {

    private readonly ApplicationDbContext _context;
    public Repository(ApplicationDbContext context)
    {
      _context = context;
    }
    public void Create(T entity)
    {
      _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
      _context.Set<T>().Remove(entity);
    }

    public T Get(Expression<Func<T, bool>> expression)
    {
      return _context.Set<T>().Where(expression).FirstOrDefault();
    }

    public IEnumerable<T> GetAll()
    {
      return _context.Set<T>().ToList();
    }

    public void Update(T entity)
    {
      _context.Set<T>().Update(entity);
    }
  }
}