using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoImpar.Domain.Interfaces.Repositories.paginated
{
    public class PaginatedParamns
    {
        public PaginatedParamns(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public PaginatedParamns()
        {
            
        }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10; 
    }
}
