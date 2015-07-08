namespace SportSystem.Data
{
    using SportSystem.Models;
    using System.Data.Entity;

    public interface ISportSystemDbContext
    {
        IDbSet<Bet> Bets { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Match> Matches { get; set; }

        IDbSet<Player> Players { get; set; }

        IDbSet<Team> Teams { get; set; }

        IDbSet<Vote> Votes { get; set; }

        int SaveChanges();
    }
}
