using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoImpar.Domain.Interfaces.Repositories.paginated
{
    public class PaginatedResult<T>
    {
        public PaginatedResult(long totalCount, int pageNumber, int pageSize, IEnumerable<T> items)
        {
            TotalCount = totalCount;
            PageNumber = pageNumber;
            PageSize = pageSize;
            Items = items;
        }

        public PaginatedResult()
        {
            
        }


        public long TotalCount { get; private set; }
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public IEnumerable<T> Items { get; private set; }


    }
}
