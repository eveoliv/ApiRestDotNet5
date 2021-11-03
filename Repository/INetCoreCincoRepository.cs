using AppNetCore5.Domain;
using System.Collections.Generic;

namespace AppNetCore5.Repository
{
    public interface INetCoreCincoRepository
    {
        public IEnumerable<Modelo> ListaAll();

        public int Insert(long id);
    }
}
