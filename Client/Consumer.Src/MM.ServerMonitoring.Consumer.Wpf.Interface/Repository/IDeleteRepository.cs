namespace MM.ServerMonitoring.Consumer.Wpf.Interface.Repository;

public interface IDeleteRepository<T>
{
    Guid Delete(Guid id);
}