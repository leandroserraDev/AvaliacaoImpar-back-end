using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoImpar.Domain.Entities.car;
using AvaliacaoImpar.Domain.Interfaces.Repositories.Base;
using AvaliacaoImpar.Domain.Interfaces.Repositories.car;
using AvaliacaoImpar.Domain.Interfaces.Services.card;
using AvaliacaoImpar.Domain.Interfaces.Services.notification;
using AvaliacaoImpar.Domain.Interfaces.Services.photo;
using AvaliacaoImpar.Services.Services.Base;

namespace AvaliacaoImpar.Services.Services.card
{
    public class ServiceCard : ServiceBase<Card>, IServiceCard
    {
        public ServiceCard(IRepositoryCard repositoryBase,
            INotificationError notificationError)
            : base(repositoryBase, notificationError)
        {
        }

        public override async Task<Card> UpdateAsync(Card entity)
        {

            //validação se existe item com o ID selecionado
            var card = await _repositoryBase.GetById(entity.Id);

            if (card == null)
            {
                _notificationError.AddNotification("Card não encontrado");

                return null;

            }

            //Atualizar informações
            card.UpdatePhoto(entity.Photo);
            card.UpdateName(entity.Name);

            //salvar novo card com as novas informação de nome, foto e 
            var result = await _repositoryBase.UpdateAsync(card);

            if (result == null)
            {
                return null;
            }

            return await Task.FromResult(entity);
        }
    }
}
