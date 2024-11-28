using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoImpar.Domain.Entities.car;
using AvaliacaoImpar.Domain.Entities.photo;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoImpar.Infra.Context
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            :base(dbContextOptions)
        {
            
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Photo> Photos{ get; set; }
    }
}
