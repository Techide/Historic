namespace Historic.Api.Common.CQS {
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult> {
        TResult Handle(TQuery query);
    }
}
