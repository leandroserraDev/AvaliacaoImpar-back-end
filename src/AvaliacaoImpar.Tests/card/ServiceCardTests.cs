using System;
using System.Threading.Tasks;
using AvaliacaoImpar.Domain.Entities.car;
using AvaliacaoImpar.Domain.Interfaces.Repositories.car;
using AvaliacaoImpar.Domain.Interfaces.Services.notification;
using AvaliacaoImpar.Services.Services.card;
using FluentValidation;
using Moq;
using Xunit;

public class ServiceCardTests
{
    private readonly Mock<IRepositoryCard> _repositoryMock;
    private readonly Mock<INotificationError> _notificationMock;
    private readonly Mock<IValidator<Card>> _validatorMock;
    private readonly ServiceCard _serviceCard;

    public ServiceCardTests()
    {
        _repositoryMock = new Mock<IRepositoryCard>();
        _notificationMock = new Mock<INotificationError>();
        _validatorMock = new Mock<IValidator<Card>>();

        _serviceCard = new ServiceCard(
            _repositoryMock.Object,
            _notificationMock.Object,
            _validatorMock.Object);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnCard_WhenValidationSucceeds()
    {
        // Arrange
        var newCard = new Card("Card 1", new AvaliacaoImpar.Domain.Entities.photo.Photo("dsa"), AvaliacaoImpar.Domain.Enums.EStatusCar.Ativo); // Nome inválido


        _validatorMock.Setup(v => v.ValidateAsync(newCard, default))
            .ReturnsAsync(new FluentValidation.Results.ValidationResult());

        _repositoryMock.Setup(r => r.CreateAsync(newCard))
            .ReturnsAsync(newCard);

        // Act
        var result = await _serviceCard.CreateAsync(newCard);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Card 1", result.Name);
        _repositoryMock.Verify(r => r.CreateAsync(newCard), Times.Once);
        _notificationMock.Verify(n => n.AddNotification(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnNull_WhenValidationFails()
    {
        // Arrange
        var newCard = new Card("", new AvaliacaoImpar.Domain.Entities.photo.Photo("dsa"), AvaliacaoImpar.Domain.Enums.EStatusCar.Ativo);

        _validatorMock.Setup(v => v.ValidateAsync(newCard, default))
            .ReturnsAsync(new FluentValidation.Results.ValidationResult(new[]
            {
                new FluentValidation.Results.ValidationFailure("Name", "Nome é obrigatório")
            }));

        // Act
        var result = await _serviceCard.CreateAsync(newCard);

        // Assert
        Assert.Null(result);
        _notificationMock.Verify(n => n.AddNotification("Nome é obrigatório"), Times.Once);
        _repositoryMock.Verify(r => r.CreateAsync(It.IsAny<Card>()), Times.Never);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNull_WhenCardNotFound()
    {
        // Arrange
        var cardId = 1;
        var updateCard = new Card(2,"Card 1", new AvaliacaoImpar.Domain.Entities.photo.Photo("dsa"), AvaliacaoImpar.Domain.Enums.EStatusCar.Ativo); // Nome inválido

        _repositoryMock.Setup(r => r.GetById(cardId))
            .ReturnsAsync((Card)null);

        // Act
        var result = await _serviceCard.UpdateAsync(updateCard);

        // Assert
        Assert.Null(result);
        _notificationMock.Verify(n => n.AddNotification("Card não encontrado"), Times.Once);
        _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<Card>()), Times.Never);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateCard_WhenValid()
    {
        // Arrange
        var existingCard = new Card(1, "Card 1", new AvaliacaoImpar.Domain.Entities.photo.Photo("dsa"), AvaliacaoImpar.Domain.Enums.EStatusCar.Ativo); // Nome inválido

        var updatedCard = new Card(1, "Card 2", new AvaliacaoImpar.Domain.Entities.photo.Photo("dsa"), AvaliacaoImpar.Domain.Enums.EStatusCar.Ativo); // Nome inválido


        _repositoryMock.Setup(r => r.GetById(existingCard.Id))
            .ReturnsAsync(existingCard);

        _repositoryMock.Setup(r => r.UpdateAsync(existingCard))
            .ReturnsAsync(existingCard);

        _validatorMock.Setup(v => v.ValidateAsync(existingCard, default))
            .ReturnsAsync(new FluentValidation.Results.ValidationResult());

        // Act
        var result = await _serviceCard.UpdateAsync(updatedCard);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Card 2", result.Name);
        _repositoryMock.Verify(r => r.UpdateAsync(It.Is<Card>(c => c.Name == "Card 2")), Times.Once);
        _notificationMock.Verify(n => n.AddNotification(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnFalse_WhenCardNotFound()
    {
        // Arrange
        var cardId =1;

        _repositoryMock.Setup(r => r.GetById(cardId))
            .ReturnsAsync((Card)null);

        // Act
        var result = await _serviceCard.DeleteAsync(cardId);

        // Assert
        Assert.False(result);
        _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<Card>()), Times.Never);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnTrue_WhenCardExists()
    {
        // Arrange
        var existingCard = new Card(1, "Card 1", new AvaliacaoImpar.Domain.Entities.photo.Photo("dsa"), AvaliacaoImpar.Domain.Enums.EStatusCar.Ativo); // Nome inválido


        _repositoryMock.Setup(r => r.GetById(existingCard.Id))
            .ReturnsAsync(existingCard);

        // Act
        var result = await _serviceCard.DeleteAsync(existingCard.Id);

        // Assert
        Assert.True(result);
        _repositoryMock.Verify(r => r.DeleteAsync(existingCard), Times.Once);
        _notificationMock.Verify(n => n.AddNotification(It.IsAny<string>()), Times.Never);
    }


}
