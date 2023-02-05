using System.Windows.Controls;
using MM.ServerMonitoring.Consumer.Wpf.Interface.View;
using Prism.Mvvm;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Shell.Views;

public class ViewViewModel : BindableBase, IViewModel
{
    private char iconChar;
    private Control view;
    private string viewName;

    public ViewViewModel(string viewInfo, char iconChar, Control view)
    {
        ViewName = viewInfo;
        IconChar = iconChar;
        View = view;
    }

    public Control View
    {
        get => view;
        set => SetProperty(ref view, value);
    }

    public string ViewName
    {
        get => viewName;
        set => SetProperty(ref viewName, value);
    }

    public char IconChar
    {
        get => iconChar;
        set => SetProperty(ref iconChar, value);
    }

    public void ViewReady()
    {
    }
}