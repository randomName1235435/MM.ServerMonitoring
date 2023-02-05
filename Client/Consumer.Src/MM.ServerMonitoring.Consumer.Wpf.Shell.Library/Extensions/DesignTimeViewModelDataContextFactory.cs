using System.ComponentModel;
using System.Windows;
using System.Windows.Markup;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Library.Extensions;

/// <summary>
///     creates generic design time viewmodel so i can use the dammed designer
/// </summary>
public class DesignTimeViewModelDataContextFactory : MarkupExtension
{
    public Type ParameterType { get; set; }
    public Type ViewModelType { get; set; }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            return null;
        if (ParameterType == null)
            return null;
        if (ViewModelType == null)
            return null;
        var genericType = ViewModelType.MakeGenericType(ParameterType);
        return Activator.CreateInstance(genericType);
    }
}