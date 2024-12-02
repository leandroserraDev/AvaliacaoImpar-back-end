using AvaliacaoImpar.Application.DTOS.card.Create;
using AvaliacaoImpar.Domain.Enums;

namespace AvaliacaoImpa.API.GraphQL.mutation.card.type
{
    public record CardUpdateGrapQLType( string name, IFile file, EStatusCar status)
    {

        public CardUpdateDTO ToDTO()
        {
            var newFormFile = new FormFile(file.OpenReadStream(), file.OpenReadStream().Position, file.OpenReadStream().Length, file.Name, file.Name);
            var newDTO = new CardUpdateDTO(name, newFormFile,status);

            return newDTO;
        }



    }
}
