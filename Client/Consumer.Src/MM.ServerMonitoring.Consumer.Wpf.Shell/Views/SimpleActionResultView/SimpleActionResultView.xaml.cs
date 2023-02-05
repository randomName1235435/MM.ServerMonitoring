using System;
using MM.ServerMonitoring.Consumer.Wpf.Interface.View;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Shell;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.SimpleActionResultView;

public partial class SimpleActionResultView : ViewBase, IView
{
    public SimpleActionResultView()
    {
        this.InitializeComponent();
    }

    private void Popup_OnOpened(object sender, EventArgs e)
    {
    }
}