using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models { 
    public class TransactionFormat
    {
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }

        public TransactionFormat(decimal sum, string from, string to)
        {
            Sum = sum;
            From = from;
            To = to;
        }
    }
}
