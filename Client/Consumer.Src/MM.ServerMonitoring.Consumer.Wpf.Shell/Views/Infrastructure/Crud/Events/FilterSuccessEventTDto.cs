using System.Collections.Generic;
using Prism.Events;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Events;

public class FilterSuccessEventTDto<TDto> : PubSubEvent<IEnumerable<TDto>>
{
}