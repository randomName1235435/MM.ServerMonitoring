﻿using Prism.Events;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure.Crud.Events;

public class SingleDataLoadedSucceedEvent<TDto> : PubSubEvent<TDto>
{
}