using Moq;
using Server.Controllers;
using Server.Data;
using Server.Exceptions;
using Server.Models;
using Server.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ServerTest.ControllersTest
{
    public class CardsControllerTest
    {
        private readonly ICardService _cardService = new CardService();
        private readonly User mockUser;
        private readonly IEnumerable<Card> mockCards;
        private readonly CardsController controller;
        private readonly Mock<IBankRepository> mock;
        private readonly string validCard;
        // Arrange
        public CardsControllerTest()
        { 
            mock = new Mock<IBankRepository>();
            mockUser = FakeDataGenerator.GenerateFakeUser();
            mockCards = FakeDataGenerator.GenerateFakeCardsToUser(mockUser);
            mock.Setup(r => r.GetCards()).Returns(mockCards);            
            controller = new CardsController(mock.Object, _cardService);
            validCard = mockCards.ElementAt(0).CardNumber;
        }

        #region Positive cases
        [Fact]
        public void GetExistingCardsPassed()
        {
            // Test
            var cards = controller.Get();

            // Assert
            mock.Verify(r => r.GetCards(), Times.AtMostOnce());
            Assert.Equal(mockCards.Count(), cards.Count());
        }

        [Fact]
        public void GetValidCardTest()
        {
            mock.Setup(x => x.GetCard(validCard)).Returns(mockCards.First(c => c.CardNumber == validCard));
            Card card = controller.Get(validCard);

            mock.Verify(r => r.GetCard(validCard), Times.AtMostOnce());
            Assert.Equal(mockCards.First(x => x.CardNumber == validCard), card);
        }

        //[Fact]
        //public void PostValidIssueDataTest()
        //{
        //    controller.Post(new CardIssueFormat("trip", 2, 2));

        //    var cards = controller.Get();

        //    var newCard = cards.FirstOrDefault(x => x.CardName == "trip");

        //    Assert.NotNull(newCard);            
        //}
        #endregion

        #region Negative cases
        [Fact]
        public void GetNotExistingCardTest()
        {
            string card = "4350 2281 3456 0896";
            Assert.Throws<UserDataException>( () => controller.Get(card));
        }
        #endregion

        //[Fact]
        //public void PostInvalidIssueDataTest()
        //{
        //    Assert.Throws<UserDataException>(() => controller.Post(new CardIssueFormat("test", 8, 0)));
        //}

    }
}