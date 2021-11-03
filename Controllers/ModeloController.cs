using System;
using AppNetCore5.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppNetCore5.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ModeloController : ControllerBase
    {
        private readonly ILogger<ModeloController> _logger;
        private readonly INetCoreCincoRepository _repository;

        public ModeloController(ILogger<ModeloController> logger, INetCoreCincoRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllData()
        {
            try
            {
                var data = _repository.ListaAll();

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter dados");
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public IActionResult SetData([FromBody] long id)
        {
            try
            {
                var result = _repository.Insert(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar inserir dados");
                return new StatusCodeResult(500);
            }
        }
    }
}
