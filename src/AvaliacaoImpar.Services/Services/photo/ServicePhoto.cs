using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoImpar.Domain.Entities.photo;
using AvaliacaoImpar.Domain.Interfaces.Repositories.Base;
using AvaliacaoImpar.Domain.Interfaces.Services.notification;
using AvaliacaoImpar.Domain.Interfaces.Services.photo;
using AvaliacaoImpar.Services.Services.Base;

namespace AvaliacaoImpar.Services.Services.photo
{
    public class ServicePhoto : ServiceBase<Photo>, IServicePhoto
    {
        public ServicePhoto(IRepositoryBase<Photo> repositoryBase, INotificationError notificationError) : base(repositoryBase, notificationError)
        {
        }
    }
}
