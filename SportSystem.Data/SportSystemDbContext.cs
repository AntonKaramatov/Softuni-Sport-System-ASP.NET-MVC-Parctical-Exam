namespace SportSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using SportSystem.Data.Migrations;
    using SportSystem.Models;
    using System.Data.Entity;

    public class SportSystemDbContext : IdentityDbContext<User>, ISportSystemDbContext
    {
        public SportSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SportSystemDbContext, Configuration>());
        }

        public static SportSystemDbContext Create()
        {
            return new SportSystemDbContext();
        }

        public IDbSet<Bet> Bets { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Match> Matches { get; set; }

        public IDbSet<Player> Players { get; set; }

        public IDbSet<Team> Teams { get; set; }

        public IDbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Match>()
                .HasRequired(m => m.AwayTeam)
                .WithMany(t => t.AwayMatches)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                .HasRequired(m => m.HomeTeam)
                .WithMany(t => t.HomeMatches)
                .WillCascadeOnDelete(false);
        }
    }    
}
