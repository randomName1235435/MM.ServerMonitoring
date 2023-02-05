namespace MM.ServerMonitoring.Consumer.Wpf.Repository.Rest.Refit;

public interface IDefaultCrudServiceAsync<T, in TKey>
    : IDefaultCreateServiceAsync<T, TKey>,
        IDefaultUpdateServiceAsync<T, TKey>,
        IDefaultDeleteServiceAsync<T, TKey>,
        IDefaultReadServiceAsync<T, TKey>
    where T : class
{
}