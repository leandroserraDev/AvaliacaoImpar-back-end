using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoImpar.Domain.Entities.photo;
using AvaliacaoImpar.Domain.Interfaces.Repositories.photo;
using AvaliacaoImpar.Domain.Interfaces.Services.notification;
using AvaliacaoImpar.Infra.Context;

namespace AvaliacaoImpar.Infra.Repositories.photo
{
    public class RepositoryPhoto : RepositoryBase<Photo>, IRepositoryPhoto
    {
        public RepositoryPhoto(ApplicationDbContext dbContext, INotificationError notificationError) : base(dbContext, notificationError)
        {
        }
    }
}
