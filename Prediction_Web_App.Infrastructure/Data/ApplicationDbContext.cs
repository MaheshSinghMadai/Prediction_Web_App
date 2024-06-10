using Microsoft.EntityFrameworkCore;
using Prediction_Web_App.Core.Entities;

namespace Prediction_Web_App.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Player_Info> Player_Infos { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }
        public DbSet<Goal_Scorer> Goal_Scorers{ get; set; }
        public DbSet<Prediction> Predictions { get; set; }
        public DbSet<Scorecard> Scorecards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Scorecard>()
                .HasNoKey();

            // Country - Player_Info relationship
            modelBuilder.Entity<Country>()
                .HasMany(c => c.Players)
                .WithOne(p => p.Country)
                .HasForeignKey(p => p.Country_Id);

            // Fixture - Prediction relationship
            modelBuilder.Entity<Fixture>()
                .HasMany(f => f.Predictions)
                .WithOne(p => p.Fixture)
                .HasForeignKey(p => p.Fixture_ID);

            // Fixture - Goal_Scorer relationship
            modelBuilder.Entity<Fixture>()
                .HasMany(f => f.Goal_Scorers)
                .WithOne(gs => gs.Fixture)
                .HasForeignKey(gs => gs.Fixture_Id);

            // Player_Info - Goal_Scorer relationship
            modelBuilder.Entity<Player_Info>()
                .HasMany(p => p.GoalScorers)
                .WithOne(gs => gs.Player)
                .HasForeignKey(gs => gs.Player_Id);
        }
    }

}
