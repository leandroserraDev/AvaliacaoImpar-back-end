using AvaliacaoImpa.API.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoImpa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        //private readonly INotificacaoErrorServico _notificationErrorService;

        //protected MainController(INotificacaoErrorServico notificationErrorService)
        //{
        //    _notificationErrorService = notificationErrorService;
        //}

        protected async Task<IActionResult> CustomResponse(object result = null, bool success = true)
        {

            if (success)
            {
                return Ok(new CustomResponse(true, result, null));
            }

            return BadRequest(new
             CustomResponse(false, result, new List<string>()));
        }
    }
}
