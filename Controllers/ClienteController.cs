using System;
using System.Threading.Tasks;
using AppNetCore5.Domain;
using AppNetCore5.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static AppNetCore5.QueriesSql.ClienteSql;

namespace AppNetCore5.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ClienteController : ControllerBase
    {        
        private readonly ILogger<ClienteController> logger;       
        private readonly IRepositoryBase<Cliente> repository;

        public ClienteController(ILogger<ClienteController> logger, IRepositoryBase<Cliente> repository)
        {
            this.logger = logger;
            this.repository = repository;
        }

        [HttpGet("GetClientes")]
        public IActionResult GetClientes()
        {
            try
            {
                return Ok( repository.FindAll(Clientes()));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao tentar obter dados em GetClientes");
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("GetClientesPorId")]
        public IActionResult GetClientesPorId(int id)
        {            
            try
            {
                return Ok(repository.FindId(ClienteId(id), id));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao tentar obter dados em GetClientePorId");
                return new StatusCodeResult(500);
            }
        }

        [HttpPost("PostCliente")]
        public IActionResult PostCliente([FromBody, Bind("Nome, Cpf, Data_Inclusao")] ClientePost cp)
        {
            try
            {             
                return Ok(repository.Insert(ClienteInsert(cp)));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao tentar inserir dados");
                return new StatusCodeResult(500);
            }
        }

        [HttpPut("PutClientePorId")]
        public IActionResult PutClientePorId([FromBody] Cliente cp)
        {
            try
            {                             
                return Ok(repository.Update(ClienteUpdate(cp)));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao tentar atualizar dados");
                return new StatusCodeResult(500);
            }
        }

        [HttpDelete("DeleteClientePorId")]
        public IActionResult DeleteClientePorId(int id)
        {
            try
            {                    
                return Ok(repository.Delete(ClienteDelete(id)));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao tentar inserir dados");
                return new StatusCodeResult(500);
            }
        }
    }
}
