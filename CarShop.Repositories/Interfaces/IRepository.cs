namespace CarShop.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    bool Insert(TEntity entity);

    bool Update(TEntity entity);

    bool Remove(TEntity entity);

    bool Remove(int id);

    TEntity GetById(int id);

    IQueryable<TEntity> GetAll();
}
