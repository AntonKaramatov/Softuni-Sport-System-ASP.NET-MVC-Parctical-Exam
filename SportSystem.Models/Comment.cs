namespace SportSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int MatchId { get; set; }

        public virtual Match Match { get; set; }
    }
}
