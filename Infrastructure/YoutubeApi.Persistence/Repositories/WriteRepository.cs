using Microsoft.EntityFrameworkCore;
using YoutubeApi.Application.Interfaces.Repositories;
using YoutubeApi.Domain.Common;
using YoutubeApi.Persistence.Context;

namespace YoutubeApi.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T>  where T : class, IEntityBase, new()
{
    private readonly AppDbContext _dbContext;
    public WriteRepository( AppDbContext context )
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

    public async Task HardDeleteRangeAsync(IList<T> entities)
    { 
        await Task.Run(() => Table.RemoveRange(entities));
    }
}