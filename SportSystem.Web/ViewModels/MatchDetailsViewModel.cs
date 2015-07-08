namespace SportSystem.Web.ViewModels
{
    using SportSystem.Common.Mappings;
    using SportSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MatchDetailsViewModel : IMapFrom<Match>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public string HomeTeamName { get; set; }

        public string AwayTeamName { get; set; }

        public DateTime Date { get; set; }

        public decimal HomeTeamBets { get; set; }

        public decimal AwayTeamBets { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Match, MatchDetailsViewModel>()
                .ForMember(x => x.AwayTeamBets, cnf => cnf.MapFrom(
                    m =>
                    m.Bets.Where(b => b.TeamId == m.AwayTeamId)
                    .Sum(v => (decimal?)v.Ammount) ?? 0))
                .ForMember(x => x.HomeTeamBets, cnf => cnf.MapFrom(
                    m =>
                    m.Bets.Where(b => b.TeamId == m.HomeTeamId)
                    .Sum(v => (decimal?)v.Ammount)  ?? 0));
        }
    }
}