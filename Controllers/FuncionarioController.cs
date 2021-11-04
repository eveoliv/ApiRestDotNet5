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
    public class FuncionarioController : ControllerBase
    {
        private readonly IRepository<Funcionario> repository;
        private readonly ILogger<FuncionarioController> logger;
        public FuncionarioController(IRepository<Funcionario> repository, ILogger<FuncionarioController> logger)
        {
            this.logger = logger;
            this.repository = repository;
        }

        [HttpGet("GetFuncionarios")]
        public IActionResult GetFuncionarios()
        {
            try
            {
                var data = repository.FindAll(QryFuncionarios());
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao tentar obter dados em GetFuncionarios");
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("GetFuncionarioPorId")]
        public IActionResult GetFuncionarioPorId(int id)
        {            
            try
            {
                var data = repository.FindId(QryFuncionarioId(id), id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao tentar obter dados em GetFuncionarioPorId");
                return new StatusCodeResult(500);
            }
        }

        [HttpPost("PostFuncionario")]
        public IActionResult PostFuncionario([FromBody, Bind("Nome, Cpf, Data_Admissao")] FuncionarioPost fp)
        {
            try
            {    
                var result = repository.Insert(InsertFuncionario(fp));
                return Ok(200);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao tentar inserir dados");
                return new StatusCodeResult(500);
            }
        }

        [HttpPut("PutFuncionarioPorId")]
        public IActionResult PutFuncionarioPorId([FromBody] Funcionario fp)
        {
            try
            {              
                var result = repository.Update(UpdateFuncionario(fp));
                return Ok(200);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao tentar atualizar dados");
                return new StatusCodeResult(500);
            }
        }

        [HttpDelete("DeleteFuncionarioPorId")]
        public IActionResult DeleteFuncionarioPorId(int id)
        {
            try
            {      
                var result = repository.Delete(DeleteFuncionario(id));

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
