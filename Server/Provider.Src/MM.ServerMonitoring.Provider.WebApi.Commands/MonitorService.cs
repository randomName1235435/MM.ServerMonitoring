// using MM.ServerMonitoring.Provider.WebApi.Interface;
// using MM.ServerMonitoring.Repository.EntityFramework;
// using MM.ServerMonitoring.Repository.EntityFramework.Interface;
// using Monitor = MM.ServerMonitoring.Repository.EntityFramework.Model.Monitor;
//
// namespace MM.ServerMonitoring.Provider.WebApi.Commands;
//
// public class MonitorService : CrudServiceBase<Monitor>, IMonitorService
// {
//     public MonitorService(IRepositoryAsync<Monitor> repository) : base(repository)
//     {
//     }
//     protected override IQueryable<Monitor> ReadInternal()
//     {
//         return repository.Read(x => x);
//     }
//
//     protected override IQueryable<Monitor> FilterByQuery(IQueryable<Monitor> query, string filter)
//     {
//         if (filter == null) return query;
//
//         return query.Where(x => (x.Name != null && x.Name.Contains(filter)) ||
//                                 (x.Description != null && x.Description.Contains(filter)));
//     }
//
//     protected override IQueryable<Monitor> EstablishNaturalOrder(IQueryable<Monitor> query)
//     {
//         return query.OrderBy(item => item.Name);
//     }
// }

