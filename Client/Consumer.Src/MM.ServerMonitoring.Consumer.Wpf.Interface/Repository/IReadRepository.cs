namespace MM.ServerMonitoring.Consumer.Wpf.Interface.Repository;

public interface IReadRepository<T>
{
    IEnumerable<T> Read();
    T Read(Guid id);
}