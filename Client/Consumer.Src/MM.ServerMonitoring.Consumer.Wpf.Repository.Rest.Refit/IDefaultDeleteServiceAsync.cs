using Refit;

namespace MM.ServerMonitoring.Consumer.Wpf.Repository.Rest.Refit;

public interface IDefaultDeleteServiceAsync<T, in TKey> where T : class
{
    [Delete("/{key}")]
    Task<Guid> DeleteAsync(TKey key);
}