using MM.ServerMonitoring.Consumer.Wpf.Interface.View;
using Prism.Events;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Events;

public class ShowInsertPageEvent<TDto> : PubSubEvent<IInsertView<TDto>>
{
}