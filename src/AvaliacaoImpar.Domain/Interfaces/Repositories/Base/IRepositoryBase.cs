﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoImpar.Domain.Entities.ValueObjects;
using AvaliacaoImpar.Domain.Interfaces.Repositories.paginated;

namespace AvaliacaoImpar.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<T> where T : EntityValueObject
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<PaginatedResult<T>> GetAllAsync(Expression<Func<T, bool>> expression, PaginatedParamns paginatedParamns);

        Task<PaginatedResult<T>> GetAllAsync(PaginatedParamns paginatedParamns);

        Task<T> GetById(long id);
    }
}
