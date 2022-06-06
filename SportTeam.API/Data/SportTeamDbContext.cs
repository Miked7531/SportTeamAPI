using Microsoft.EntityFrameworkCore;

namespace SportTeam.API.Data
{
    public class SportTeamDbContext : DbContext
    {
        public SportTeamDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    Id = 1,
                    Name = "Raiders",
                    Location = "Oakland"
                },
                new Team
                {
                    Id = 2,
                    Name = "Cowboys",
                    Location = "Dallas"
                },
                new Team
                {
                    Id = 3,
                    Name = "Panthers",
                    Location = "Charlotte"
                }
            );
            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Bobby",
                    TeamId = 1
                },
                new Player
                {
                    Id = 2,
                    FirstName = "Jack",
                    LastName = "Samson",
                    TeamId = 2
                },
                new Player
                {
                    Id = 3,
                    FirstName = "Sam",
                    LastName = "Winchester",
                    TeamId = 3 
                }
            );
        }

    }
}
