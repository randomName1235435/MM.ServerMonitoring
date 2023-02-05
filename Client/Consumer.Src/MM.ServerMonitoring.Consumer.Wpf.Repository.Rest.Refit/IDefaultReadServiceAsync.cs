using Refit;

namespace MM.ServerMonitoring.Consumer.Wpf.Repository.Rest.Refit;

public interface IDefaultReadServiceAsync<T, in TKey> where T : class
{
    [Get("")]
    Task<List<T>> GetAllAsync();

    [Get("/{key}")]
    Task<T> GetAsync(TKey key);
}