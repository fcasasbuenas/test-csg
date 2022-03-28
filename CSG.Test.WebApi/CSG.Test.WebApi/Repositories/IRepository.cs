using System.Collections.Generic;

namespace CSG.Test.WebApi.Repositories
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        TEntity Get(long id);

        void Add(TEntity entity);

        void Update(TEntity dbEntity, TEntity entity);

        void Delete(TEntity entity);
    }
}