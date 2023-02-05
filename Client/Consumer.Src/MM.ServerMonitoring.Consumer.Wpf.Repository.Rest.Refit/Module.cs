using MM.ServerMonitoring.Consumer.Wpf.Interface;
using MM.ServerMonitoring.Consumer.Wpf.Model;
using Refit;
using Monitor = MM.ServerMonitoring.Provider.WebApi.Dto.Model.Crud.Monitor;

namespace MM.ServerMonitoring.Consumer.Wpf.Repository.Rest.Refit;

//todo use module infrastructure und extract view to own project
public class Module : IModule
{
    public void Init(IContainer container)
    {
        var configuration = container.Resolve<IEnvironmentConfiguration>().Get();
        AddToContainer<IDefaultCrudServiceAsync<Monitor, Guid>>(container, configuration, "monitor");
    }

    private static void AddToContainer<TCrud>(IContainer container, Configuration configuration, string apiSuffix)
    {
        var service = RestService.For<TCrud>(configuration.BaseApiAdress + apiSuffix);
        container.RegisterInstance(service);
    }
}