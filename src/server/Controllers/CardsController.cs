using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Exceptions;
using Server.Infrastructure;
using Server.Models;
using Server.Services;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class CardsController : Controller
    {
        private readonly IBankRepository repository;

        private readonly ICardService cardService;

        public CardsController(IBankRepository repository, ICardService cardService)
        {
            this.repository = repository;
            this.cardService = cardService;
        }

        // GET api/cards
        [HttpGet]
        public IEnumerable<Card> Get() => repository.GetCards();

        // GET api/cards/5334343434343...
        [HttpGet("{number}")]
        public Card Get(string number)
        {
            // check card number
            if (!cardService.CheckCardEmmiter(number))
                throw new UserDataException("Card number is invalid", number);
            //TODO validation
            return repository.GetCard(number);
        }

        // POST api/cards
        [HttpPost]
        public IActionResult Post([FromBody] CardIssueFormat card)
        {
            if (card == null || !ModelState.IsValid)
            {
                throw new UserDataException("Data for card issue is invalid", String.Empty);
            }
            // check currency and cardType codes 
            Currency currency = cardService.ValidateCurrency(card.Currency);
            CardType cardType = cardService.ValidateCardType(card.CardType);

            // open new card
            repository.OpenNewCard(card.CardName, currency, cardType);

            // return 200 and new card instance
            return Ok(repository.GetCards().Last());
        }

        // DELETE api/cards/5
        [HttpDelete("{number}")]
        public IActionResult Delete(string number) => StatusCode(405);

        //TODO PUT method
    }
}
