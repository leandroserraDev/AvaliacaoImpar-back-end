using AvaliacaoImpa.API.GraphQL.mutation.card.type;
using AvaliacaoImpa.API.response;
using AvaliacaoImpar.Application.DTOS.card;
using AvaliacaoImpar.Application.DTOS.card.Create;
using AvaliacaoImpar.Application.Interfaces.Services.Card;
using AvaliacaoImpar.Domain.Interfaces.Services.notification;
using AvaliacaoImpar.Services.Services.Notification;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoImpa.API.GraphQL.mutation.card
{
    public class CardMutation
    {

        public CardMutation(IApplicationServiceCard applicationServiceCard, INotificationError notificationError)
        {
   
        }

        public async Task<Response<CardViewDTO>> CreateCardAsync(
            [FromServices] IApplicationServiceCard applicationServiceCard,
            [FromServices]INotificationError notificationError,
          
            CardCreateGrapQLType cardCreateDTO)
        {
            var result = await applicationServiceCard.CreateAsync(cardCreateDTO.ToDTO());

            if (result != null)
            {
                var response = new Response<CardViewDTO>(true, result);
                return response;

            }
            else
            {
                return new Response<CardViewDTO>(false, null, await notificationError.GetNotifications());
                ;
            }
        }

        public async Task<Response<CardViewDTO>> UpdateCardAsync( int id, CardUpdateGrapQLType cardUpdateGrapQLType,
                 [FromServices] IApplicationServiceCard applicationServiceCard,
            [FromServices] INotificationError notificationError)
        {
            var result = await applicationServiceCard.UpdateAsync(id, cardUpdateGrapQLType.ToDTO());

            if (result != null)
            {
                var response = new Response<CardViewDTO>(true, result);
                return response;

            }
            else
            {
                return new Response<CardViewDTO>(false, null, await notificationError.GetNotifications());
                ;

            }
        } 


        public async Task<Response<bool>> Delete([FromServices] IApplicationServiceCard applicationServiceCard,
            [FromServices] INotificationError notificationError, int id)
        {
            var resultDelete = await applicationServiceCard.Delete(id);

            return new Response<bool>(resultDelete, resultDelete, await notificationError.GetNotifications());
        }
    }
}
