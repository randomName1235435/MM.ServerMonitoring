using System;
using MM.ServerMonitoring.Consumer.Wpf.Interface.Repository;
using MM.ServerMonitoring.Consumer.Wpf.Repository.Rest.Refit;
using MM.ServerMonitoring.Provider.WebApi.Dto.Model.DtoModel.Read;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Services;

public class DashboardReadRepository : IDashboardReadRepository

{
    private readonly IDashboardReadServiceAsync service;

    public DashboardReadRepository(IDashboardReadServiceAsync service)
    {
        _ = service ?? throw new ArgumentNullException(nameof(service));

        this.service = service;
    }

    public DashboardDto Read()
    {
        return service.GetAsync().ConfigureAwait(false).GetAwaiter().GetResult();
    }
}