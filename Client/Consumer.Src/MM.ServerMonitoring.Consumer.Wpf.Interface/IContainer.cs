using MM.ServerMonitoring.Consumer.Wpf.Interface.View;

namespace MM.ServerMonitoring.Consumer.Wpf.Interface;

public interface IContainer
{
    void Register<TInterface, TImplementation>() where TImplementation : TInterface;
    void RegisterType<TImplementation>();
    void RegisterInstance<T>(T implementation);

    void RegisterView<TView, TViewModel>()
        where TView : class, IView
        where TViewModel : class, IViewModel;

    void RegisterView<TView, TViewModel, TViewInterface>()
        where TView : class, IView, TViewInterface
        where TViewModel : class, IViewModel
        where TViewInterface : IView;

    TImplementation Resolve<TImplementation>();
    TImplementation RegisterResolve<TImplementation>();
    bool IsRegistered<TImplementation>();
}