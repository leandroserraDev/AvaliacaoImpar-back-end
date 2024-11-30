using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoImpar.Domain.Entities.car;
using AvaliacaoImpar.Domain.Interfaces.Repositories.car;
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
           return await _dbContext.Cars.AnyAsync(obj => 
           !obj.Id.Equals(id)
           &&
           obj.Name.ToLower().Equals(name.ToLower()));
        }

        public override async Task<Card> GetById(long id)
        {
            var result = _dbContext.Cars.Include(obj => obj.Photo)
                .FirstOrDefault(obj => obj.Id.Equals(id));

            return await Task.FromResult(result);
        }
    }
}
