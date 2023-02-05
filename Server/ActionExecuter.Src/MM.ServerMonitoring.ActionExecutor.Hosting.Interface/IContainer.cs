namespace MM.ServerMonitoring.ActionExecutor.Interface;

public interface IContainer
{
    void Register<TInterface, TImplementation>() where TImplementation : TInterface;
    T Resolve<T>();
}