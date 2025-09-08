using Microsoft.EntityFrameworkCore;
using YoutubeApi.Application.Interfaces.Repositories;
using YoutubeApi.Domain.Common;

namespace YoutubeApi.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T>  where T : class, IEntityBase, new()
{
    private readonly DbContext _dbContext;
    public WriteRepository( DbContext context )
    {
        this._dbContext = context;
    }
    
    private DbSet<T> Table  { get => _dbContext.Set<T>(); }
    
    public async Task AddAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public async Task AddRangeAsync(IList<T> entities)
    {
        await Table.AddRangeAsync(entities);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        await Task.Run(() => Table.Update(entity));
        return entity;
    }

    public async Task HardDeleteAsync(T entity)
    {
        await Task.Run(() => Table.Remove(entity));
    }
}