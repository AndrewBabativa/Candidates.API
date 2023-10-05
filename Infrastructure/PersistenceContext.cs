using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Candidates.Models;
using System.Threading.Tasks;

namespace Candidates.Infrastructure
{
    public class CandidatesContext : DbContext
    {
        private readonly IConfiguration Config;

        public CandidatesContext(DbContextOptions<CandidatesContext> options, IConfiguration config) : base(options)
        {
            Config = config;
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateExperience> CandidateExperiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Config.GetValue<string>("SchemaName"));

            modelBuilder.Entity<Candidate>()
                .HasMany(c => c.CandidateExperiences);

            base.OnModelCreating(modelBuilder);
        }
    }
}
