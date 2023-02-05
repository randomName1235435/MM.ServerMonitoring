namespace MM.ServerMonitoring.Provider.WebApi.Interface;

public interface IContainer
{
    void Register<TInterface, TImplementation>() where TImplementation : TInterface;
    T Resolve<T>();
}