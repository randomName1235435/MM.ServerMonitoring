namespace MM.ServerMonitoring.Consumer.Wpf.Interface.Repository;

public interface IUpdateRepository<T>
{
    Guid Update(T param);
}