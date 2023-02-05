namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Library.Extensions;

public static class Repeat
{
    public static Task FromInterval(TimeSpan pollInterval, Action action, CancellationToken token)
    {
        return Task.Factory.StartNew(
            () =>
            {
                for (;;)
                {
                    if (token.WaitCancellationRequested(pollInterval))
                        break;

                    action();
                }
            }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
    }
}