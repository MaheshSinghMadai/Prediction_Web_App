using Microsoft.EntityFrameworkCore;
using Prediction_Web_App.Core.Entities;
using Prediction_Web_App.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Prediction_Web_App.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<Player_Info> Player_Infos { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }
        public DbSet<Goal_Scorer> Goal_Scorers{ get; set; }
        public DbSet<Prediction> Predictions { get; set; }
    }

}
