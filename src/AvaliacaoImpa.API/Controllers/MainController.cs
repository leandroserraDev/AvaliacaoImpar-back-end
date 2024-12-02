using AvaliacaoImpa.API.response;
using AvaliacaoImpar.Domain.Interfaces.Services.notification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoImpa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly INotificationError _notificationError;

        protected MainController(INotificationError notificationError)
        {
            _notificationError = notificationError;
        }

        protected async Task<IActionResult> CustomResponse(object result = null)
        {

            if (await _notificationError.HasNotifications())
            {

                return base.BadRequest(new
                 Response<dynamic>(false, result, _notificationError.GetNotifications().Result));
            }

            return base.Ok(new Response<dynamic>(true, result, null));

        }
    }
}
