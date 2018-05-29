using Historic.Api.Utils.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Historic.Api.Data.Models {
    public class HistoricContext : DbContext {
        private readonly ConnectionstringSettings _settings;

        public HistoricContext(ConnectionstringSettings settings) {
            _settings = settings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(_settings.DefaultConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
        }

        public DbSet<Campaign> Campaigns { get; set; }
    }
}
