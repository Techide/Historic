using Historic.Api.Common.CQS;
using Historic.Api.Data.Models;
using System;

namespace Historic.Api.Common {
    public abstract class ADbQueryHandler<TQuery, TResult> : IDbQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult> {

        public ADbQueryHandler(HistoricContext context) {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public HistoricContext Context { get; }

        public abstract TResult Handle(TQuery query);
    }
}
