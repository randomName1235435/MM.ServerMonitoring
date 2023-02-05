using Refit;

namespace MM.ServerMonitoring.Consumer.Wpf.Repository.Rest.Refit;

public interface IDefaultCreateServiceAsync<T, in TKey> where T : class
{
    [Post("")]
    Task<Guid> CreateAsync([Body] T payload);
}