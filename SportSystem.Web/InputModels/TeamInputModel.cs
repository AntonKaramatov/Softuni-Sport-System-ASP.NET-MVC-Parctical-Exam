namespace SportSystem.Web.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using SportSystem.Models;
    using SportSystem.Common.Mappings;
    using System.Linq;

    public class TeamInputModel : IMapTo<Team>
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} is required")]
        public string Name { get; set; }

        [Display(Name = "Nickname")]
        public string NickName { get; set; }

        [Url]
        public string Website { get; set; }

        [Display(Name = "Founded")]
        public DateTime? DateFounded { get; set; }

        [Display(Name = "Player")]
        public IList<int> PlayersIds { get; set; }
    }
}