namespace SportSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public double Height { get; set; }

        public int? TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}
