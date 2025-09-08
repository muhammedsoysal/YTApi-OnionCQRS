using YoutubeApi.Application.Interfaces.Repositories;
using YoutubeApi.Application.Interfaces.UnitOfWorks;
using YoutubeApi.Domain.Common;
using YoutubeApi.Persistence.Context;
using YoutubeApi.Persistence.Repositories;

namespace YoutubeApi.Persistence.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();
    public IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new() => new ReadRepository<T>(_dbContext);
    public IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new() => new WriteRepository<T>(_dbContext);
    public async Task<int> SaveAsync() => await _dbContext.SaveChangesAsync();
    public int Save() => _dbContext.SaveChanges();
}