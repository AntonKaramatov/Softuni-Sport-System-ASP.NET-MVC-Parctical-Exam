namespace SportSystem.Web.ViewModels
{
    using SportSystem.Common.Mappings;
    using SportSystem.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PlayerViewModel : IMapFrom<Player>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Born")]
        public DateTime BirthDate { get; set; }

        public double Height { get; set; }
    }
}
