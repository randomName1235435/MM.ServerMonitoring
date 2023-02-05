using System.Collections.Generic;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView.Misc;

public class MonitorDependents
{
    public IEnumerable<IdNamePair> Targets { get; set; }
    public IEnumerable<IdNamePair> Actions { get; set; }
    public IEnumerable<IdNamePair> Parameter { get; set; }
}