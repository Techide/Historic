namespace Historic.Api.Common.CQS {
    public interface ICommandHandler<TCommand> where TCommand : ICommand {
        void Handle(TCommand command);
    }
}
