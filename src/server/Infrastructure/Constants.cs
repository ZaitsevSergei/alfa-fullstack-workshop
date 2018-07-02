using System;
using System.Collections.Generic;

namespace Server.Infrastructure
{
    /// <summary>
    /// Static utils constraint class
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// BIN references for alfabank cards
        /// </summary>
        public static string[] AlfaBINs = {
                "408396",
                "408397",
                "410584",
                "415400",
                "415428",
                "415429",
                "415481",
                "415482",
                "419539",
                "419540",
                "426101",
                "426102",
                "426113",
                "426114",
                "427714",
                "428804",
                "428905",
                "428906",
                "431416",
                "431417",
                "431727",
                "434135",
                "438143",
                "439000",
                "439077",
                "440237",
                "458279",
                "458280",
                "458281",
                "458410",
                "458411",
                "458443",
                "458450",
                "465227",
                "475791",
                "477714",
                "477932",
                "477960",
                "477964",
                "478752",
                "479004",
                "479087",
                "480623",
                "510126",
                "519747",
                "519778",
                "521178",
                "522828",
                "523701",
                "530827",
                "531237",
                "537643",
                "548601",
                "548655",
                "548673",
                "548674",
                "552175",
                "552186",
                "555156",
                "555921",
                "555928",
                "555933",
                "555947",
                "555949",
                "555957",
                "558334",
                "627119",
                "676230"
        };

        // exchange rate dictionary
        public static Dictionary<string, decimal> ExchangeRate = new Dictionary<string, decimal>()
        {
            { "USDRUB", 63.13m },
            { "USDEUR", 0.8m },
            { "RUBUSD", 0.015m },
            { "RUBEUR", 0.013m },
            { "EURUSD", 1.16m},
            { "EURRUB", 73.48m }
        };

    }
}