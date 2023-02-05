using LanguageExt;
using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Validation;
using MM.ServerMonitoring.Repository.EntityFramework.Interface;
using MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;

namespace MM.ServerMonitoring.Provider.WebApi.Validation;

public class DependencyValidation<TEntity> where TEntity : class, IHasId
{
    private static readonly string isRequired = "missing";
    private static readonly string notFound = "not found";
    private static readonly string notUnique = "already used";

    private static readonly string hasReferences = "has references";

    public static Option<ValidationMessage> NotEmptyAndFound(Guid property, string nameOf,
        ICrudServiceAsync<TEntity> service)
    {
        if (property == Guid.Empty)
            return new ValidationMessage { TargetPath = nameOf, Message = isRequired };

        if (service.FindById(property) == null)
            return new ValidationMessage { TargetPath = nameOf, Message = notFound };
        return Option<ValidationMessage>.None;
    }

    public static Option<ValidationMessage> NotEmptyAndNotFound(Guid property, string nameOf,
        ICrudServiceAsync<TEntity> service)
    {
        if (property == Guid.Empty)
            return new ValidationMessage { TargetPath = nameOf, Message = isRequired };

        if (service.FindById(property) != null)
            return new ValidationMessage { TargetPath = nameOf, Message = notUnique };
        return Option<ValidationMessage>.None;
    }

    public static Option<ValidationMessage> MustNotFound<TDepdency>(Guid property,
        string nameOf,
        ICrudServiceAsync<TDepdency> service,
        Func<TDepdency, bool> find)
        where TDepdency : class, IHasId
    {
        if (service.Read(q => q.Where(find)).Any())
            return new ValidationMessage { TargetPath = nameOf, Message = hasReferences };
        return Option<ValidationMessage>.None;
    }
}