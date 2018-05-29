using Historic.Api.Common.CQS;
using Historic.Api.Data.Models;

namespace Historic.Api.Common {
    public interface IDbQueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult> {
        HistoricContext Context { get; }
    }
}
