using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoImpar.Domain.Entities.car;
using AvaliacaoImpar.Domain.Entities.photo;
using AvaliacaoImpar.Domain.Interfaces.Repositories.car;
using AvaliacaoImpar.Domain.Interfaces.Repositories.paginated;
using AvaliacaoImpar.Domain.Interfaces.Services.notification;
using AvaliacaoImpar.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoImpar.Infra.Repositories.car
{
    public class RepositoryCard : RepositoryBase<Card>, IRepositoryCard 
    {
        public RepositoryCard(ApplicationDbContext dbContext, INotificationError notificationError) : base(dbContext, notificationError)
        {
        }

        public async Task<bool> BeUniqueCardByName(long id, string name)
        {
           return await _dbContext.Cards.AnyAsync(obj => 
           !obj.Id.Equals(id)
           &&
           obj.Name.ToLower().Equals(name.ToLower()));
        }

        public override async Task<Card> GetById(long id)
        {
            var result = _dbContext.Cards.Include(obj => obj.Photo)
                .FirstOrDefault(obj => obj.Id.Equals(id));

            return await Task.FromResult(result);
        }

        public override async Task<PaginatedResult<Card>> GetAllAsync(Expression<Func<Card, bool>> expression, PaginatedParamns paginatedParamns)
        {
            var queryResult = 
                _dbContext
                .Cards
                .Where(expression)
                .OrderBy(obj => obj.Id)
                .Select(obj => new Card(obj.Id, obj.Name, new Photo(obj.Photo.Base64), obj.Status ))
                    .Skip(((int)paginatedParamns.PageNumber - 1) * 10) // Pula os registros já exibidos
                    .Take(10).ToList();// Limita os resultados ao tamanho da página

            var totalCount = await _dbContext.Cards.Where(expression).CountAsync();

            return await ReturnPaginated(totalCount,queryResult, paginatedParamns);
        }
    }
}
