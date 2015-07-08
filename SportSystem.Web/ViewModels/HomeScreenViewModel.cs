namespace SportSystem.Web.ViewModels
{
    using System.Collections.Generic;

    public class HomeScreenViewModel
    {
        public IEnumerable<MatchViewModel> Matches { get; set; }

        public IEnumerable<TeamViewModel> Teams { get; set; }
    }
}