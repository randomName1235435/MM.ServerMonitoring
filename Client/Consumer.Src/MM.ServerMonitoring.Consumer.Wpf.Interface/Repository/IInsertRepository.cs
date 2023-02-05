namespace MM.ServerMonitoring.Consumer.Wpf.Interface.Repository;

public interface IInsertRepository<T>
{
    Guid Insert(T param);
}