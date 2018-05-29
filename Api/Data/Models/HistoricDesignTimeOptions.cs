using Historic.Api.Utils.Settings;
using Microsoft.Extensions.Options;

namespace Historic.Api.Data.Models {
    public class HistoricDesignTimeOptions : IOptions<ConnectionstringSettings> {
        private readonly string _connectionString;

        public HistoricDesignTimeOptions(string connectionString) {
            _connectionString = connectionString;
        }

        public ConnectionstringSettings Value => new ConnectionstringSettings { DefaultConnection = _connectionString };
    }

}
