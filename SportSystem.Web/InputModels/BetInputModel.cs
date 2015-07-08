namespace SportSystem.Web.InputModels
{
    using SportSystem.Common.Mappings;
    using SportSystem.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BetInputModel : IMapTo<Bet>
    {
        public int MatchId { get; set; }

        public int TeamId { get; set; }

        [Range(0.01, Double.MaxValue)]
        public decimal Ammount { get; set; }
    }
}