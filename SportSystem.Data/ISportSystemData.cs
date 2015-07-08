namespace SportSystem.Data
{
    using SportSystem.Data.Repositories;
    using SportSystem.Models;

    public interface ISportSystemData
    {
        IRepository<User> Users { get; }

        IRepository<Bet> Bets { get; }

        IRepository<Comment> Comments { get; }
        
        IRepository<Match> Matches { get; }
        
        IRepository<Player> Players { get; }
        
        IRepository<Team> Teams { get; }
        
        IRepository<Vote> Votes { get; }

        int SaveChanges();
    }
}
