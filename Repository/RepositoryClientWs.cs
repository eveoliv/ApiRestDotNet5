using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AppNetCore5.Repository
{
    public interface IRepositoryClient<TEntity> where TEntity : class
    {
        Task<TEntity[]> GetResponseWs(string url);
    }

    public class RepositoryClientWs<TEntity> : IRepositoryClient<TEntity> where TEntity : class
    {
        public async Task<TEntity[]> GetResponseWs(string url)
        {
            using var client = new HttpClient();
            return JsonConvert.DeserializeObject<List<TEntity>>(await client.GetStringAsync(url)).ToArray();
        }
    }
}
