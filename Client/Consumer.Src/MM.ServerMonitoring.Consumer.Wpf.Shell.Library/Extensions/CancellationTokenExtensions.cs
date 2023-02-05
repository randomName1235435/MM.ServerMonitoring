namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Library.Extensions;

public static class CancellationTokenExtensions
{
    public static bool WaitCancellationRequested(
        this CancellationToken token,
        TimeSpan timeout)
    {
        return token.WaitHandle.WaitOne(timeout);
    }
}