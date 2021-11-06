using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace AppNetCore5.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> FindAll(string qry);
        IEnumerable<TEntity> FindId(string qry, int id);
        TEntity Insert(string qry);
        TEntity Update(string qry);
        TEntity Delete(string qry);
    }
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity :class
    {
        private readonly string connectionString;        
        public RepositoryBase(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConn");        
        }

        public IEnumerable<TEntity> FindAll(string qry)
        {
            using var connection = new SqlConnection(connectionString);
            return connection.Query<TEntity>(qry);
        }

        public IEnumerable<TEntity> FindId(string qry, int id)
        {
            using var connection = new SqlConnection(connectionString);          
            return connection.Query<TEntity>(qry);            
        }              

        public TEntity Insert(string qry) => Operacoes(qry, out _);
        
        public TEntity Update(string qry) => Operacoes(qry, out _);
        
        public TEntity Delete(string qry) => Operacoes(qry, out _);
        
        private TEntity Operacoes(string qry, out SqlConnection connection)
        {
            connection = new SqlConnection(connectionString);
            return connection.Execute(qry) as TEntity;
        }
       
    }
}
