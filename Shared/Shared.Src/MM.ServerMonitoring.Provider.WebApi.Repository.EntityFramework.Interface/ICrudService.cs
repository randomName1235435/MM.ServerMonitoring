using MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;

namespace MM.ServerMonitoring.Repository.EntityFramework.Interface;

//todo:validation everywhere?
public interface ICrudService<TType> : IQueryService<TType> where TType : class, IHasId
{
    TType FindByIdWithIncludes(Guid id);
    TType FindById(Guid id);
    IEnumerable<TType> Read();

    IEnumerable<TType> Read(Func<IQueryable<TType>, IEnumerable<TType>> query);

    IEnumerable<TType> ReadWithIncludes();
    IEnumerable<TType> ReadWithIncludes(Func<IQueryable<TType>, IEnumerable<TType>> query);

    void Insert(TType item);
    Guid Update(TType item);
    void Delete(Guid id);
}