using System;
using AppNetCore5.Domain;
using System.Threading.Tasks;
using AppNetCore5.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace AppNetCore5.Controllers
{
    public class TradeController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<TradeController> logger;
        private readonly IRepositoryClient<Trade> repository;

        public TradeController(IRepositoryClient<Trade> repository, ILogger<TradeController> logger, IConfiguration configuration)
        {
            this.logger = logger;
            this.repository = repository;
            this.configuration = configuration;
        }

        [HttpGet("GetTransacoesCriptoMoedasMercadoBitcoin")]
        public async Task<IActionResult> GetTransacoes(string coin)
        {
            try
            {
                return Ok(await repository.GetResponseWs($@"{configuration.GetValue<string>("AppSettings:WsUrl")}{coin.ToUpper()}{configuration.GetValue<string>("AppSettings:key")}"));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Falha ao executar requisição GetTransaçoes.");
                return new StatusCodeResult(500);
            }            
        }
    }
}
