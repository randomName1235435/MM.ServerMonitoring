using System;
using System.ComponentModel;
using System.Windows;
using Prism.Mvvm;
using IContainer = MM.ServerMonitoring.Consumer.Wpf.Interface.IContainer;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Shell;

public class ShellViewModelBase : BindableBase
{
    protected readonly IContainer container;

    public ShellViewModelBase(IContainer container)
    {
        if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            return;
        _ = container ?? throw new ArgumentNullException(nameof(container));
        this.container = container;
    }
}