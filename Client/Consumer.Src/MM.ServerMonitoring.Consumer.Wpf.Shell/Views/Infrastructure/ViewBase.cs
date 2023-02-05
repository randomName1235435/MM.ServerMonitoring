using System;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure;

public class ViewBase : UserControl
{
    public void NotifyOnLoaded(Action notify)
    {
        Loaded += (_, _) => notify?.Invoke();
    }

    /// <summary>
    ///     need to update source for shitty wpf builtin validation
    ///     gets called from xaml
    ///     cant be static, cause CallMethodAction will not work
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void UpdateSourceFromSelectedItemBindingExpression(dynamic sender, SelectionChangedEventArgs e)
    {
        if (sender is not ComboBox comboBox)
            return;
        comboBox.GetBindingExpression(Selector.SelectedItemProperty).UpdateSource();
    }
}