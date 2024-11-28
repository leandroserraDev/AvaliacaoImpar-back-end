using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoImpar.Domain.Entities.car;
using AvaliacaoImpar.Domain.Interfaces.Repositories.car;
using AvaliacaoImpar.Infra.Context;

namespace AvaliacaoImpar.Infra.Repositories.car
{
    public class RepositoryCar : RepositoryBase<Car>, IRepositoryCar
    {
        public RepositoryCar(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
