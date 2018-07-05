using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    /// <summary>
    /// Format to issue card
    /// </summary>
    public class CardIssueFormat
    {
        [Required]
        public string CardName { get; set; }

        [Required]
        public int Currency { get; set; }

        [Required]
        public int CardType { get; set; }
    }
}
