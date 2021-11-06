using System;
using AppNetCore5.Domain;
using AppNetCore5.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static AppNetCore5.QueriesSql.FuncionarioSql;

namespace AppNetCore5.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly ILogger<FuncionarioController> logger;
        private readonly IRepositoryBase<Funcionario> repository;
        public FuncionarioController(IRepositoryBase<Funcionario> repository, ILogger<FuncionarioController> logger)
        {
            this.logger = logger;
            this.repository = repository;
        }

        [HttpGet("GetFuncionarios")]
        public IActionResult GetFuncionarios()
        {
            try
            {
                var data = repository.FindAll(Funcionarios());
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
                var data = repository.FindId(FuncionarioId(id), id);
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
                var result = repository.Insert(FuncionarioInsert(fp));
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
                var result = repository.Update(FuncionarioUpdate(fp));
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
                var result = repository.Delete(FuncionarioDelete(id));

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
