using System.Linq.Expressions;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Entities.UserEntity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Abstractions.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly CredoDbContext _context;
    private readonly DbSet<T> _set;

    protected BaseRepository(CredoDbContext context)
    {
        _context = context;
        _set = _context.Set<T>();
    }

    public IQueryable<T> Set => _set;

    public T? Get(Expression<Func<T, bool>> expression)
    {
        return Set.FirstOrDefault(expression);
    }

    public Task<T?> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        return _set.FirstOrDefaultAsync(expression, cancellationToken);
    }

    public IQueryable<T> List(Expression<Func<T, bool>>? expression = default,
                              Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = default)
    {
        IQueryable<T> set = _context.Set<T>();

        if (expression != default)
        {
            set = set.Where(expression);
        }

        if (orderBy != default)
        {
            set = orderBy(set);
        }

        return set.AsNoTracking();
    }

    public void Add(T entity)
    {
        _context.Add(entity);
    }

    public void Update(T entity)
    {
        if (_context.Attach(entity).State == EntityState.Detached)
        {
            _context.Attach(entity);
        }

        _context.Attach(entity).State = EntityState.Modified;
    }
}