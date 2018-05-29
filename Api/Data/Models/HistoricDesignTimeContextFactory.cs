using Historic.Api.Utils.Settings;
using Microsoft.EntityFrameworkCore.Design;

namespace Historic.Api.Data.Models {

    public class HistoricDesignTimeContextFactory : IDesignTimeDbContextFactory<HistoricContext> {

        public HistoricContext CreateDbContext(string[] args) {
            var designtimeConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Historic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var options = new ConnectionstringSettings { DefaultConnection = designtimeConnectionString };
            return new HistoricContext(options);
        }
    }
}
