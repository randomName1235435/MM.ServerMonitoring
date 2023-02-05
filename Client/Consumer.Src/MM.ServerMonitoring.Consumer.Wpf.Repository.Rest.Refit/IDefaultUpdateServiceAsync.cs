using Refit;

namespace MM.ServerMonitoring.Consumer.Wpf.Repository.Rest.Refit;

public interface IDefaultUpdateServiceAsync<T, in TKey> where T : class
{
    [Put("/update/{key}")]
    Task<Guid> UpdateAsync(TKey key, [Body] T payload);
}