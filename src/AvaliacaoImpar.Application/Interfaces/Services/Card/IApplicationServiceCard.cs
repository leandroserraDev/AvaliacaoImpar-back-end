using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoImpar.Application.DTOS.card;
using AvaliacaoImpar.Application.DTOS.card.Create;
using AvaliacaoImpar.Domain.Interfaces.Repositories.paginated;

namespace AvaliacaoImpar.Application.Interfaces.Services.Card
{
    public interface IApplicationServiceCard
    {
        Task<CardViewDTO> CreateAsync(CardCreateDTO entity);
        Task<CardViewDTO> UpdateAsync(long id,CardUpdateDTO entity);
        Task<PaginatedResult<CardViewDTO>> GetAllAsync(PaginatedParamns paginatedParamns);

        Task<bool> Delete(long id);


        Task<CardViewDTO> GetById(long id);


    }
}
