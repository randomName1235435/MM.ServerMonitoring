using MM.ServerMonitoring.Consumer.Wpf.Interface.View;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Infrastructure;
using MM.ServerMonitoring.Consumer.Wpf.Shell.Views.Shell;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.Crud;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Views.MonitorView.Edit;

public partial class EditView : ViewBase, IEditView<Monitor>
{
    public EditView()
    {
        this.InitializeComponent();
    }
}