using AutoMapper;
using Server.Models;
using Server.Services;

namespace Server.Map
{
    /// <summary>
    /// Converter for Transaction model to TransactionDto
    /// </summary>
    public class TransactionConvertercs : ITypeConverter<Transaction, TransactionDto>
    {
        private readonly IBusinessLogicService businessLogicService;
        private readonly ICardService cardService;

        public TransactionConvertercs(IBusinessLogicService businessLogicService,
            ICardService cardService)
        {
            this.businessLogicService = businessLogicService;
            this.cardService = cardService;
        }

        public TransactionDto Convert(Transaction source, TransactionDto destination, ResolutionContext context)
        {
            return new TransactionDto
            {
                DateTime = source.DateTime,
                From = source.CardFromNumber,
                To = source.CardToNumber,
                Sum = source.Sum,
                Credit = source.CardToNumber == cardService.CreateNormalizeCardNumber(source.CardToNumber)
            };
        }
    }
}
