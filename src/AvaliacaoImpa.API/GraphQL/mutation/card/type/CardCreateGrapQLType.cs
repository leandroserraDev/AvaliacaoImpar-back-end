﻿using AvaliacaoImpar.Application.DTOS.card.Create;
using AvaliacaoImpar.Domain.Enums;

namespace AvaliacaoImpa.API.GraphQL.mutation.card.type
{
    public record CardCreateGrapQLType(string cardName, IFile file)
    {

        public CardCreateDTO ToDTO()
        {
            var newFormFile = new FormFile(file.OpenReadStream(), file.OpenReadStream().Position, file.OpenReadStream().Length, file.Name, file.Name);
            var newDTO = new CardCreateDTO(cardName, newFormFile);

            return newDTO;
        }



    }
}
