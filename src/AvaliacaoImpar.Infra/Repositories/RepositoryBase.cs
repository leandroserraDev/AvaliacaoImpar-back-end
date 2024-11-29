using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoImpar.Domain.Entities.ValueObjects;
using AvaliacaoImpar.Domain.Interfaces.Repositories.Base;
using AvaliacaoImpar.Domain.Interfaces.Repositories.paginated;
using AvaliacaoImpar.Domain.Interfaces.Services.notification;
using AvaliacaoImpar.Infra.Context;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace AvaliacaoImpar.Infra.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityValueObject
    {
        protected ApplicationDbContext _dbContext;
        private readonly INotificationError _notificationError;

        public RepositoryBase(ApplicationDbContext dbContext, INotificationError notificationError)
        {
            _dbContext = dbContext;
            _notificationError = notificationError;
        }

        public async Task<T> CreateAsync(T entity)
        {
            try
            {

                var result = _dbContext.Set<T>().Add(entity);

                _dbContext.SaveChanges();

                return await Task.FromResult(entity);
            }
            catch (Exception ex)
            {

                return null;
            }

        }


        public async Task DeleteAsync(T entity)
        {
            try
            {

                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex) { }

        }

        public async Task<PaginatedResult<T>> GetAllAsync(Expression<Func<T, bool>> expression, PaginatedParamns paginatedParamns)
        {
            var queryResult = _dbContext.Set<T>()
                             .Where(expression)
                             .Skip((paginatedParamns.PageNumber - 1) * 10) // Pula os registros já exibidos
                             .Take(10).ToList();// Limita os resultados ao tamanho da página

            return await ReturnPaginated(queryResult, paginatedParamns);

        }

        public async Task<PaginatedResult<T>> GetAllAsync(PaginatedParamns paginatedParamns)
        {
            var queryResult = _dbContext.Set<T>()
                     .Skip((paginatedParamns.PageNumber - 1) * 10) // Pula os registros já exibidos
                     .Take(10).ToList();// Limita os resultados ao tamanho da página

            return await ReturnPaginated(queryResult, paginatedParamns);


        }

        public virtual async Task<T> GetById(long id)
        {
            var result = await _dbContext.Set<T>().FindAsync(id);

            return await Task.FromResult(result);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {

                _dbContext.Set<T>().Update(entity);
                await _dbContext.SaveChangesAsync();

                return await Task.FromResult(entity);
            }
            catch (Exception ex)
            {

                return null;
            }
        }


        private async Task<PaginatedResult<T>> ReturnPaginated(List<T> entities, PaginatedParamns paginatedParamns)
        {
            var totalCounts = entities.Count;
            var result = new PaginatedResult<T>(totalCounts, paginatedParamns.PageNumber, (int)Math.Ceiling(totalCounts / (double)paginatedParamns.PageSize), entities);

            return await Task.FromResult(result);
        }

    }
}
