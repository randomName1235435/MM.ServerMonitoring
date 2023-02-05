namespace MM.ServerMonitoring.Provider.WebApi.Interface.Command;

public interface IReadCommand<TResult>
{
    Task<TResult> ExecuteAsync(CancellationToken cancellationToken);
    TResult Execute();
}

// public interface IReadByIdCommand<TResult>
// {
//     Task<TResult> ExecuteAsync(CancellationToken cancellationToken);
//     TResult Execute();
// }

//
// //readcommand
// //readbyid command
// //delete by id command
// //update command
//
//
//
// public interface ICommand<TResult>
// {
//     Task<TResult> ExecuteAsync(CancellationToken cancellationToken);
//     TResult Execute();
// }
//
// public interface ICommand<in TParameter1, TResult>
// {
//     Task<TResult> ExecuteAsync(TParameter1 item, CancellationToken cancellationToken);
//     TResult Execute(TParameter1 item);
// }
//
// public interface ICommand<in TParameter1, in TParameter2, TResult>
// {
//     Task<TResult> ExecuteAsync(TParameter1 item1, TParameter2 item2);
//     TResult Execute(TParameter1 item1, TParameter2 item2);
// }
//
// public interface ICommand<in TParameter1, in TParameter2, in TParameter3, TResult>
//
// {
//     TResult Execute(TParameter1 item1, TParameter2 item2, TParameter3 item3);
//     Task<TResult> ExecuteAsync(TParameter1 item1, TParameter2 item2, TParameter3 item3);
// }
//
// public interface ICommand<in TParameter1, in TParameter2, in TParameter3, in TParameter4, TResult>
// {
//     TResult Execute(TParameter1 item1, TParameter2 item2, TParameter3 item3, TParameter4 item4);
//     Task<TResult> ExecuteAsync(TParameter1 item1, TParameter2 item2, TParameter3 item3, TParameter4 item4);
// }