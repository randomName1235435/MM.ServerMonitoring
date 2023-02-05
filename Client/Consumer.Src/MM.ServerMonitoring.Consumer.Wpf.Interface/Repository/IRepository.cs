namespace MM.ServerMonitoring.Consumer.Wpf.Interface.Repository;

public interface IRepository<T> :
    IDeleteRepository<T>,
    IInsertRepository<T>,
    IUpdateRepository<T>,
    IReadRepository<T>
{
}