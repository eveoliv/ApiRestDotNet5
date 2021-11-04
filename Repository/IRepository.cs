using System.Collections.Generic;

namespace AppNetCore5.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> FindAll(string qry);
        IEnumerable<TEntity> FindId(string qry, int id);
        TEntity Insert(string qry);
        TEntity Update(string qry);
        TEntity Delete(string qry);
    }
}
