using System;
using MM.ServerMonitoring.Consumer.Wpf.Interface.View;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Shell;

public partial class ShellWindow : WindowBase, IView
{
    public ShellWindow()
    {
        this.InitializeComponent();
    }

    private void MainWindow_OnClosed(object sender, EventArgs e)
    {
        if (DataContext is ShellViewModel)
            ((ShellViewModel)DataContext).ViewClosed();
    }
}