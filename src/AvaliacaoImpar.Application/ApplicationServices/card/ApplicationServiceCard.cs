using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoImpar.Application.DTOS.card;
using AvaliacaoImpar.Application.DTOS.card.Create;
using AvaliacaoImpar.Application.Interfaces.Services.Card;
using AvaliacaoImpar.Domain.Interfaces.Services.card;

namespace AvaliacaoImpar.Application.ApplicationServices.card
{
    public class ApplicationServiceCard : IApplicationServiceCard
    {
        private readonly IServiceCard _serviceCard;

        public ApplicationServiceCard(IServiceCard serviceCard)
        {
            _serviceCard = serviceCard;
        }

        public async Task<CardViewDTO> CreateAsync(CardCreateDTO entity)
        {
            var cardDomain = entity.ToDomain();

            var result = await _serviceCard.CreateAsync(cardDomain);
            if (result == null) return null;
            return  await Task.FromResult(new CardViewDTO(result.Id,result.Name, result.Photo.Base64, result.Status));
        }

        public async Task<CardViewDTO> GetById(long id)
        {
            var result = await _serviceCard.GetById(id);

            if(result == null)
            {
                return null;
            }

            return await Task.FromResult(new CardViewDTO(result.Id, result.Name, result.Photo.Base64, result.Status));
        }

        public async Task<CardViewDTO> UpdateAsync(long id,CardUpdateDTO entity)
        {
            var cardDomain = entity.ToDomain(id);

            var result = await _serviceCard.UpdateAsync(cardDomain);

            return await Task.FromResult(new CardViewDTO(result.Id, result.Name, result.Photo.Base64, result.Status));
        }
    }
}
