namespace SportSystem.Web.ViewModels
{
    using SportSystem.Common.Mappings;
    using SportSystem.Models;
    using System;

    public class MatchViewModel : IMapFrom<Match>
    {
        public int Id { get; set; }

        public string HomeTeamName { get; set; }

        public string AwayTeamName { get; set; }

        public DateTime Date { get; set; }
    }
}
