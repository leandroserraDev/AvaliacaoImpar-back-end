using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoImpar.Domain.Entities.car;
using AvaliacaoImpar.Domain.Interfaces.Repositories.car;
using FluentValidation;

namespace AvaliacaoImpar.Domain.Validators.card
{
    public class CardValidator : BaseValidator<Card>
    {
        private readonly IRepositoryCard _repositoryCard;

        public CardValidator(IRepositoryCard repositoryCard)
        {
            _repositoryCard = repositoryCard;
            RuleFor(obj => obj.Name)
        .NotNull()
        .NotEmpty()
        .WithMessage("O nome do card é obrigatório")
      .Length(5, 35)
      .WithMessage("O Tamanho do nome deve ser entre 5 a 35 caracteres");

            RuleFor(obj => obj)
            .MustAsync(BeUniqueName).WithMessage("Nome deve ser unico");
        }


        private async Task<bool> BeUniqueName(Card card, CancellationToken cancellationToken)
        {


            return !await _repositoryCard.BeUniqueCardByName(card.Id, card.Name);
        }

    }
}
