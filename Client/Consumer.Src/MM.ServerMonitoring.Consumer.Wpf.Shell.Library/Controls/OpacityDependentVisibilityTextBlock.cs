using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Library.Controls;

/// <summary>
///     cause cant use a trigger in style to set visibility dependent on opacity if i bind visibility to vm
/// </summary>
public class OpacityDependentVisibilityTextBlock : TextBlock
{
    public OpacityDependentVisibilityTextBlock()
    {
        DependencyPropertyDescriptor
            .FromProperty(OpacityProperty, typeof(OpacityDependentVisibilityTextBlock))
            .AddValueChanged(this, (s, e) =>
            {
                if (Opacity != 0)
                    return;
                Visibility = Visibility.Hidden;
            });
    }
}