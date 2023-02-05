using Prism.Events;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Events;

public class InsertFailedEvent<TDto> : PubSubEvent<TDto>
{
}