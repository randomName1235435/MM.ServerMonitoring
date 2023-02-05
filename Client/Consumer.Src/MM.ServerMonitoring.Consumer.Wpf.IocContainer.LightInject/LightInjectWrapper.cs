using LightInject;
using MM.ServerMonitoring.Consumer.Wpf.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Interface.View;

namespace MM.ServerMonitoring.Consumer.Wpf.IocContainer.LightInject;

public class LightInjectWrapper : ServiceContainer, IContainer
{
    private readonly ILogger logger;

    public LightInjectWrapper(ILogger logger)
    {
        this.logger = logger;
        _ = logger ?? throw new ArgumentNullException(nameof(logger));

        this.RegisterInstance(logger);
        this.RegisterInstance<IContainer>(this);
    }

    public new void Register<TInterface, TImplementation>()
        where TImplementation : TInterface
    {
        base.Register<TInterface, TImplementation>();
        this.logger.Info($"Registered {typeof(TImplementation).FullName}");
    }

    public void RegisterView<TView, TViewModel>()
        where TView : class, IView
        where TViewModel : class, IViewModel
    {
        this.RegisterType<TViewModel>();
        base.Register<TView, TView>(typeof(TView).FullName);
        base.Register(CreateViewAndViewModel<TView, TViewModel>);
        this.logger.Info($"Registered {typeof(TView).FullName}");
    }

    public void RegisterView<TView, TViewModel, TViewInterface>()
        where TView : class, IView, TViewInterface
        where TViewModel : class, IViewModel
        where TViewInterface : IView
    {
        this.RegisterType<TViewModel>();
        base.Register<TView, TView>(typeof(TView).FullName);
        base.Register<TViewInterface>(CreateViewAndViewModel<TView, TViewModel>);
        this.logger.Info($"Registered {typeof(TView).FullName} with interface {typeof(TViewInterface).FullName}");
    }

    public void RegisterType<TImplementation>()
    {
        base.Register<TImplementation>();
        this.logger.Info($"Registered {typeof(TImplementation).FullName}");
    }

    public TInterface Resolve<TInterface>()
    {
        var result = this.GetInstance<TInterface>();
        this.logger.Info($"Resolved {typeof(TInterface).FullName}");
        return result;
    }

    public new void RegisterInstance<TInterface>(TInterface instance)
    {
        base.RegisterInstance(typeof(TInterface), instance);
        this.logger.Info($"Registered {typeof(TInterface).FullName}");
    }

    public bool IsRegistered<TImplementation>()
    {
        return this.CanGetInstance(typeof(TImplementation), string.Empty);
    }

    public TImplementation RegisterResolve<TImplementation>()
    {
        if (!this.CanGetInstance(typeof(TImplementation), string.Empty)) this.RegisterType<TImplementation>();
        return this.Resolve<TImplementation>();
    }

    private static TView CreateViewAndViewModel<TView, TViewModel>(IServiceFactory serviceFactory)
        where TView : class, IView
        where TViewModel : class, IViewModel
    {
        var view = serviceFactory.GetInstance<TView>(typeof(TView).FullName);
        var viewModel = serviceFactory.Create<TViewModel>();

        view.DataContext = viewModel;
        view.NotifyOnLoaded(() => viewModel.ViewReady());
        return view;
    }
}