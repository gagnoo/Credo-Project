using System.Linq.Expressions;
using Domain.Entities.UserEntity;

namespace Domain.Abstractions.Repositories;

public interface IBaseRepository<T>
{
    IQueryable<T> Set { get; }
    T? Get(Expression<Func<T, bool>> expression);
    Task<T?> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);

    IQueryable<T> List(Expression<Func<T, bool>>? expression = default,
                       Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = default);

    void Add(T entity);
    void Update(T entity);
}