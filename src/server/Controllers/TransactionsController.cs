using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

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

        [HttpGet("{cardNumber}")]
        public IEnumerable<Transaction> Get([FromQuery] int from, string cardNumber)
    }
}
