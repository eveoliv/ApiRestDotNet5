using System;
using AppNetCore5.Domain;
using AppNetCore5.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static AppNetCore5.Repository.RepositoryQuery;

namespace AppNetCore5.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IRepository<Cliente> repository;
        private readonly ILogger<ClienteController> logger;
        public ClienteController(IRepository<Cliente> repository, ILogger<ClienteController> logger)
        {
            this.logger = logger;
            this.repository = repository;
        }

        [HttpGet("GetClientes")]
        public IActionResult GetClientes()
        {
            try
            {
                var data = repository.FindAll(QryClientes());
                return Ok(data);
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
                var data = repository.FindId(QryClienteId(id), id);
                return Ok(data);
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
                var result = repository.Insert(InsertCliente(cp));
                return Ok(200);
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
                var result = repository.Update(UpdateCliente(cp));
                return Ok(200);
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
                var result = repository.Delete(DeleteCliente(id));

                return Ok(200);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao tentar inserir dados");
                return new StatusCodeResult(500);
            }
        }
    }
}
