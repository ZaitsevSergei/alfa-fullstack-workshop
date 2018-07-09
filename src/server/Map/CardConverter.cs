using AutoMapper;
using Server.Models;
using Server.Services;
using Server.ViewModels;

namespace Server.Map
{
    /// <summary>
    /// Converter for Card model to CardDto
    /// </summary>
    public class CardConverter : ITypeConverter<Card, CardDto>
    {
        private readonly IBusinessLogicService businessLogicService;
        private readonly ICardService cardService;

        public CardConverter(IBusinessLogicService businessLogicService, ICardService cardService)
        {
            this.businessLogicService = businessLogicService;
            this.cardService = cardService;
        }

        public CardDto Convert(Card source, CardDto destination, ResolutionContext context)
        {
            return new CardDto
            {
                Number = source.CardNumber,
                Type = (int)source.CardType,
                Name = source.CardName,
                Currency = (int)source.Currency,
                Exp = cardService.GetExpDateFromDateTime(source.DTOpenCard, source.ValidityYear),
                Balance = businessLogicService.GetRoundBalanceOfCard(source)
            };
        }
    }
}
