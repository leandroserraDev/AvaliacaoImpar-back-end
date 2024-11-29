using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoImpar.Domain.Entities.car;
using Microsoft.AspNetCore.Http;

namespace AvaliacaoImpar.Application.DTOS.card.Create
{
    public record CardCreateDTO(string nameCard, IFormFile base64File)
    {


        public Card ToDomain()
        {

            using (var memoryStream = new MemoryStream())
            {
                base64File.CopyTo(memoryStream);
                var fileBytes = memoryStream.ToArray();
                var base64String = Convert.ToBase64String(fileBytes);

                // Aqui você pode usar o base64String, por exemplo, salvar no banco de dados
                // Exemplo fictício:
                var newCard = new Card(nameCard, new Domain.Entities.photo.Photo(base64String), Domain.Enums.EStatusCar.Ativo);
                
                return newCard;

            }


        }
    }

}
