using AvaliacaoImpa.API.response;
using AvaliacaoImpar.Application.ApplicationServices.card;
using AvaliacaoImpar.Application.DTOS.card;
using AvaliacaoImpar.Application.Interfaces.Services.Card;
using AvaliacaoImpar.Domain.Interfaces.Repositories.paginated;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoImpa.API.GraphQL.query.card
{
    public  class CardQuery 
    {
        public  async Task<Response<PaginatedResult<CardViewDTO>>> GetPaginated([FromServices] IApplicationServiceCard applicationServiceCard, PaginatedParamns paginatedParamns)
        {
            var result = await Task.FromResult(await applicationServiceCard.GetAllAsync(paginatedParamns));

          
                var response = new Response<PaginatedResult<CardViewDTO>>(true, result);
                return response;
       
        }

        public async Task<Response<CardViewDTO>> GetById([FromServices] IApplicationServiceCard applicationServiceCard, int id)
        {
            return new Response<CardViewDTO>(true, await Task.FromResult(await applicationServiceCard.GetById(id)));
        }
    }
}
