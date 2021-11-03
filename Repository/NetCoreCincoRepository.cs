using Dapper;
using AppNetCore5.Domain;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace AppNetCore5.Repository
{
    public class NetCoreCincoRepository : INetCoreCincoRepository
    {
        private readonly string connectionString;

        public NetCoreCincoRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("DefaultConn");
        }

        public IEnumerable<Modelo> ListaAll()
        {
            using var connection = new SqlConnection(connectionString);

            var result = connection.Query<Modelo>("select * from MODELO");

            return result;
        }
        public int Insert(long id)
        {
            using var connection = new SqlConnection(connectionString);

            var query = "insert into modelo (id)values (@id)";

            var result = connection.Execute(query, new { id });

            return result;
        }
    }
}
