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
    public class TransactionsController : Controller
    {
        private readonly IBankRepository repository;

        private readonly ICardService cardService;

        public TransactionsController(IBankRepository repository, ICardService cardService)
        {
            this.repository = repository;
            this.cardService = cardService;
        }

        // GET api/transactions/(card number)/?from=
        [HttpGet("{cardNumber}")]
        public IEnumerable<Transaction> Get([FromQuery(Name = "from")] int from, string cardNumber)
        {
            if (!cardService.CheckCardEmmiter(cardNumber))
                throw new UserDataException("Card number is invalid", cardNumber);

            return repository.GetTranasctions(cardNumber, from);
        }

        // POST api/transactions
        [HttpPost]
        public IActionResult Post([FromBody] TransactionFormat data)
        {
            if (!ModelState.IsValid || data == null)
                //throw new HttpStatusCodeException(400, "all fields must be filled");


            //return Ok(Json(repository.TransferMoney(data.sum, data.from, data.to)));
        }

        // DELETE api/transaction/5
        [HttpDelete("{number}")]
        //public IActionResult Delete(string number) => throw new HttpStatusCodeException(405, "Method Not Allowed");

        //PUT api/transaction/
        [HttpPut]
        //public IActionResult Put(object data) => throw new HttpStatusCodeException(405, "Method Not Allowed");
    }
}
