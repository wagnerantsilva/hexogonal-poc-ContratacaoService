using Contratacao.Adapters.Inbound.DTOs;
using Contratacao.Application.UseCases.ContratarProposta;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Contratacao.Adapters.Inbound.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContratacaoController : ControllerBase
    {
        private readonly IContratarPropostaUseCase _contratarPropostaUseCase;

        public ContratacaoController(IContratarPropostaUseCase contratarPropostaUseCase)
        {
            _contratarPropostaUseCase = contratarPropostaUseCase;
        }

        [HttpPost]
        public IActionResult Contratar([FromBody] ContratacaoRequest request)
        {
            try
            {
                _contratarPropostaUseCase.ExecuteAsync(request.PropostaId);
                return Ok(new { message = "Proposta contratada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
