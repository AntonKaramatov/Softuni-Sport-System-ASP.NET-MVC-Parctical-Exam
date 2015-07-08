namespace SportSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Bet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int MatchId { get; set; }

        public virtual Match Match { get; set; }

        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        public decimal Ammount { get; set; }
    }
}
