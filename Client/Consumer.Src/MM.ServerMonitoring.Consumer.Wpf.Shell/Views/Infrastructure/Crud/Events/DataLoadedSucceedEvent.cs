using System.Collections.Generic;
using Prism.Events;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Events;

public class DataLoadedSucceedEvent<TDto> : PubSubEvent<IEnumerable<TDto>>
{
}