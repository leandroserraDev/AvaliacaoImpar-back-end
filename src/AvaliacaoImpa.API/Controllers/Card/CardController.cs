using AvaliacaoImpar.Application.DTOS.card.Create;
using AvaliacaoImpar.Application.Interfaces.Services.Card;
using AvaliacaoImpar.Domain.Interfaces.Services.notification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoImpa.API.Controllers.Card
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : MainController
    {


        private readonly IApplicationServiceCard _applicationServiceCard;

        public CardController(IApplicationServiceCard applicationServiceCard, INotificationError notificationError): base(notificationError)
        {
            _applicationServiceCard = applicationServiceCard;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CardCreateDTO entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _applicationServiceCard.CreateAsync(entity);

                if(result == null)
                {
                    return await CustomResponse();
                }


                return await CustomResponse(result);


            }

            return await CustomResponse();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromForm] CardUpdateDTO entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _applicationServiceCard.UpdateAsync(id,entity);

                if (result == null)
                {
                    return BadRequest();
                }


                return await CustomResponse(result);


            }

            return await CustomResponse();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _applicationServiceCard.GetById(id);

            if (result == null) return await CustomResponse();

            return await CustomResponse(result);
        }
    }
}
