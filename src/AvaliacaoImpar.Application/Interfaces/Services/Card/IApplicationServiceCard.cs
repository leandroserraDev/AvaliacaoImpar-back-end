using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoImpar.Application.DTOS.card;
using AvaliacaoImpar.Application.DTOS.card.Create;

namespace AvaliacaoImpar.Application.Interfaces.Services.Card
{
    public interface IApplicationServiceCard
    {
        Task<CardViewDTO> CreateAsync(CardCreateDTO entity);
        Task<CardViewDTO> UpdateAsync(long id,CardUpdateDTO entity);

        Task<CardViewDTO> GetById(long id);


    }
}
