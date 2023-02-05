using MM.ServerMonitoring.Consumer.Wpf.Interface.View;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Crud;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView.Insert;

public partial class InsertView : ViewBase, IInsertView<Monitor>
{
    public InsertView()
    {
        this.InitializeComponent();
    }
}