using System.Collections.ObjectModel;
using MM.ServerMonitoring.ActionExecutor.Actions.HttpRequest;
using MM.ServerMonitoring.ActionExecutor.Actions.PingAction;
using MM.ServerMonitoring.ActionExecutor.Infrastructure;
using MM.ServerMonitoring.ActionExecutor.Interface;
using MM.ServerMonitoring.ActionExecutor.Model;

namespace MM.ServerMonitoring.ActionExecutor.Services;

public static class Default
{
    private static readonly Lazy<ReadOnlyDictionary<Guid, Func<ActionConfiguration, IAction>>> actionFactoryCollection
        = CreateLazyDefaultActionCollection();

    public static ReadOnlyDictionary<Guid, Func<ActionConfiguration, IAction>>
        ActionFactories =>
        actionFactoryCollection.Value;

    private static Lazy<ReadOnlyDictionary<Guid, Func<ActionConfiguration, IAction>>>
        CreateLazyDefaultActionCollection()
    {
        return new Lazy<ReadOnlyDictionary<Guid, Func<ActionConfiguration, IAction>>>(() =>
        {
            var dictionary = new Dictionary<Guid, Func<ActionConfiguration, IAction>>();

            AddPingAction(dictionary);
            AddHttpRequestAction(dictionary);

            return dictionary.AsReadOnlyDictionary();
        }, LazyThreadSafetyMode.PublicationOnly);
    }

    private static void AddPingAction(IDictionary<Guid, Func<ActionConfiguration, IAction>> dictionary)
    {
        dictionary.Add(Constants.ActionIds.Ping,
            configuration => new ActionPing(configuration, new ActionPingParameterMapper()));
    }

    private static void AddHttpRequestAction(IDictionary<Guid, Func<ActionConfiguration, IAction>> dictionary)
    {
        dictionary.Add(Constants.ActionIds.HttpRequest,
            configuration => new ActionHttpRequest(configuration, new ActionHttpRequestParameterMapper()));
    }
}