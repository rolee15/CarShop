using CarShop.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Repositories;

public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbContext _ctx;

    public EfRepository(DbContext ctx) {
        _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
    }

    public bool Insert(TEntity entity)
    {
        _ctx.Set<TEntity>().Add(entity);
        return Commit();
    }

    public bool Update(TEntity entity)
    {
        _ctx.Set<TEntity>().Update(entity);
        return Commit();
    }

    public bool Remove(TEntity entity)
    {
        _ctx.Set<TEntity>().Remove(entity);
        return Commit();
    }

    public bool Remove(int id)
    {
        TEntity entity = GetById(id);
        return Remove(entity);
    }

    public TEntity GetById(int id)
    {
        return _ctx.Set<TEntity>().Find(id);
    }

    public IQueryable<TEntity> GetAll()
    {
        return _ctx.Set<TEntity>();
    }

    public bool Commit()
    {
        return _ctx.SaveChanges() > 0;
    }
}
