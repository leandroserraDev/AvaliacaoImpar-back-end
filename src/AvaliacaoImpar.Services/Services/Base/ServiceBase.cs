using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoImpar.Domain.Entities.ValueObjects;
using AvaliacaoImpar.Domain.Interfaces.Repositories.Base;
using AvaliacaoImpar.Domain.Interfaces.Repositories.paginated;
using AvaliacaoImpar.Domain.Interfaces.Services.Base;
using AvaliacaoImpar.Domain.Interfaces.Services.notification;

namespace AvaliacaoImpar.Services.Services.Base
{
    public class ServiceBase<T> : IServiceBase<T> where T : EntityValueObject
    {
        protected IRepositoryBase<T> _repositoryBase;
        protected INotificationError _notificationError;

        public ServiceBase(IRepositoryBase<T> repositoryBase, INotificationError notificationError)
        {
            _repositoryBase = repositoryBase;
            _notificationError = notificationError;
        }

        public async Task<T> CreateAsync(T entity)
        {
           return await _repositoryBase.CreateAsync(entity);
            
        }

        public virtual async Task<T> UpdateAsync( T entity)
        {
            return await _repositoryBase.UpdateAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
          await _repositoryBase.DeleteAsync(entity);
            
        }

        public async Task<PaginatedResult<T>> GetAllAsync(Expression<Func<T, bool>> expression, PaginatedParamns paginatedParamns)
        {
            return await _repositoryBase.GetAllAsync(expression, paginatedParamns);
        }

        public Task<PaginatedResult<T>> GetAllAsync(PaginatedParamns paginatedParamns)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetById(long id)
        {
           return await _repositoryBase.GetById(id);
        }

    }
}
