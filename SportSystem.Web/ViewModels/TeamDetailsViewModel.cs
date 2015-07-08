namespace SportSystem.Web.ViewModels
{
    using SportSystem.Common.Mappings;
    using SportSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class TeamDetailsViewModel : IMapFrom<Team>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Nickname")]
        public string NickName { get; set; }

        [Display(Name = "Founded")]
        public DateTime DateFounded { get; set; }

        public int Votes { get; set; }

        public bool HasVoted { get; set; }

        public IEnumerable<PlayerViewModel> Players { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Team, TeamDetailsViewModel>()
                .ForMember(x => x.Votes, cnf => cnf.MapFrom(m => m.Votes.Count()));
        }
    }
}